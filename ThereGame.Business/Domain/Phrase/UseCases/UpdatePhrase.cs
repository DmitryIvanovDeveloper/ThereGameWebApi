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

        var phrase = _dataService.Phrases.
            AsNoTracking()
            .FirstOrDefault(phrase => phrase.Id == request.Phrase.Id)
        ;
        
        if (phrase != null && 
            phrase.AudioPhrase != request.Phrase.AudioPhrase)
        {
            var audioData = await _speechTextGeneratorService.Generate(request.Phrase.Text);
            request.Phrase.AudioPhrase = audioData;
        }

        _dataService.Phrases.Update(request.Phrase);

        await _dataService.SaveChanges(cancellationToken);
    }
}