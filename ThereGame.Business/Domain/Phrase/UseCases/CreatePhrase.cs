namespace ThereGame.Business.Domain.Dialogue.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;
using ThereGame.Business.Domain.Phrase;

public class CreatePhraseRequest : IRequest
{
    public required PhraseModel Phrase { get; set; }
}

public class CreatePhrase(IThereGameDataService dataService, 
    ISpeechTextGeneratorService speechTextGeneratorService) : IRequestHandler<CreatePhraseRequest>
{
    private readonly IThereGameDataService _dataService = dataService;
    private readonly ISpeechTextGeneratorService _speechTextGeneratorService = speechTextGeneratorService;

    public async Task Handle(CreatePhraseRequest request, CancellationToken cancellationToken)
    {
        if (request.Phrase == null)
        {
            return;
        }
        
        var audioData = await _speechTextGeneratorService.Generate(request.Phrase.Text);
        request.Phrase.AudioPhrase = audioData;

        await _dataService.Phrases.AddAsync(request.Phrase, cancellationToken);

        await _dataService.SaveChanges(cancellationToken);
    }
}