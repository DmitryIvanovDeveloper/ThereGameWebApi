namespace ThereGame.Business.Domain.Dialogue.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;

public class DeletePhraseRequest : IRequest
{
    public Guid Id { get; set; }
}

public class DeletePhrase(IThereGameDataService dataService, IRemoveDialogueItems removeDialogueItems) : IRequestHandler<DeletePhraseRequest>
{
    private readonly IThereGameDataService _dataService = dataService;
    private readonly IRemoveDialogueItems _removeDialogueItems = removeDialogueItems;
    
    public async Task Handle(DeletePhraseRequest request, CancellationToken cancellationToken)
    {
        var phrase = _dataService.Phrases.Find(request.Id);
        if (phrase == null) {
            return;
        }

        // _dataService.Phrases.Remove(phrase);
        _removeDialogueItems.Remove(phrase, cancellationToken);
        
        await _dataService.SaveChanges(cancellationToken);
    }
}