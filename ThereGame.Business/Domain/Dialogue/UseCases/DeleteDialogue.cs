namespace ThereGame.Business.Domain.Dialogue.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;

public class DeleteDialogueRequest : IRequest
{
    public Guid Id { get; set; }
}

public class DeleteDialogue(
    IThereGameDataService dataService, 
    IRemoveDialogueItems removeDialogueItems) : IRequestHandler<DeleteDialogueRequest>
{
    private readonly IThereGameDataService _dataService = dataService;
    private readonly IRemoveDialogueItems _removeDialogueItems = removeDialogueItems;
    
    public async Task Handle(DeleteDialogueRequest request, CancellationToken cancellationToken)
    {
        // await _dataService.RemoveFullDialogueById(request.Id, cancellationToken);
        var dialogue = await _dataService.Dialogues.FindAsync(request.Id);
        if (dialogue == null)
        {
            return;
        }
        
        _dataService.Dialogues.Remove(dialogue);
        await _dataService.SaveChanges(cancellationToken);
    }
}