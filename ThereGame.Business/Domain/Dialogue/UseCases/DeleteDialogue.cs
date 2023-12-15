namespace ThereGame.Business.Domain.Dialogue.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class DeleteDialogueRequest : IRequest
{
    public Guid Id { get; set; }
}

public class DeleteDialogue(IThereGameDataService dataService) : IRequestHandler<DeleteDialogueRequest>
{
    private readonly IThereGameDataService _dataService = dataService;
    
    public async Task Handle(DeleteDialogueRequest request, CancellationToken cancellationToken)
    {
       var dialogue = _dataService.Dialogues.Find(request.Id);
        if (dialogue == null) {
            return;
        }

        _dataService.Dialogues.Remove(dialogue);

        await _dataService.SaveChanges(cancellationToken);
    }
}