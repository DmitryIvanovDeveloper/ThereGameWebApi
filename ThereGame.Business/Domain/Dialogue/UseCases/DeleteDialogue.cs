namespace ThereGame.Business.Domain.Dialogue.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;

public class DeleteDialogueRequest : IRequest
{
    public Guid Id { get; set; }
}

public class DeleteDialogue(
    IThereGameDataService dataService) : IRequestHandler<DeleteDialogueRequest>
{
    private readonly IThereGameDataService _dataService = dataService;
    
    public async Task Handle(DeleteDialogueRequest request, CancellationToken cancellationToken)
    {
        await _dataService.RemoveDialogueCascade(request.Id);
        await _dataService.SaveChanges(cancellationToken);
    }
}