namespace ThereGame.Business.Domain.Dialogue.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;
using ThereGame.Business.Domain.Phrase;

public class UpdatePhraseRequest : IRequest
{
    public required PhraseModel Phrase { get; set; }
}

public class UpdatePhrase(IThereGameDataService dataService) : IRequestHandler<UpdatePhraseRequest>
{
    private readonly IThereGameDataService _dataService = dataService;
    
    public async Task Handle(UpdatePhraseRequest request, CancellationToken cancellationToken)
    {
        if(request.Phrase == null) {
            return;
        }

        _dataService.Phrases.Update(request.Phrase);

        await _dataService.SaveChanges(cancellationToken);
    }
}