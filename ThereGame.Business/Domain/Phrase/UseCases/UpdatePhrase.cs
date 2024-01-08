namespace ThereGame.Business.Domain.Dialogue.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;
using ThereGame.Business.Domain.Phrase;
using Microsoft.EntityFrameworkCore;

public class UpdatePhraseRequest : IRequest
{
    public required PhraseModel Phrase { get; set; }
}

public class UpdatePhrase(IThereGameDataService dataService,
  ISpeechTextGeneratorService speechTextGeneratorService) : IRequestHandler<UpdatePhraseRequest>
{
    private readonly IThereGameDataService _dataService = dataService;
    private readonly ISpeechTextGeneratorService _speechTextGeneratorService = speechTextGeneratorService;
    
    public async Task Handle(UpdatePhraseRequest request, CancellationToken cancellationToken)
    {
        if(request.Phrase == null) {
            return;
        }

        var phrase = _dataService.Phrases
            .AsNoTracking()
            .FirstOrDefault(phrase => phrase.Id == request.Phrase.Id)
        ;

        if (phrase == null || 
            request.Phrase == null)
        {
            return;
        }

        var audioSettings = _dataService.AudioSettings
            .AsNoTracking()
            .FirstOrDefault(a => a.ParentPhraseId == request.Phrase.Id)
        ;

        if (request.Phrase != null && request.Phrase.Text != "" &&
            audioSettings != null &&
            request.Phrase.AudioSettings.Id != audioSettings.Id)
        {
            audioSettings.AudioData = await _speechTextGeneratorService.Generate(request.Phrase.AudioSettings.GenerationSettings, 0);;
            audioSettings.GenerationSettings = request.Phrase.AudioSettings.GenerationSettings;
            audioSettings.Revision = audioSettings.Revision + 1;
        }

        var updatedPhrase = new PhraseModel
        {
            Id = request.Phrase.Id,
            Text = request.Phrase.Text,
            Tenseses = request.Phrase.Tenseses,
            Comments = request.Phrase.Comments,
            AudioSettings = audioSettings,
            ParentAnswer = request.Phrase.ParentAnswer,
            ParentAnswerId = request.Phrase.ParentAnswerId,
        };
        _dataService.Phrases.Update(updatedPhrase);

        await _dataService.SaveChanges(cancellationToken);
    }
}