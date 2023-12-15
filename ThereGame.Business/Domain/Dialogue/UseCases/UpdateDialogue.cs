namespace ThereGame.Business.Domain.Dialogue.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;

public class UpdateDialogueRequest : IRequest
{
    public required Guid Id { get; set;}
    public required string Name { get; set;}
    public required Guid PhraseId { get; set;}
}

public class UpdateDialogue(IThereGameDataService dataService) : IRequestHandler<UpdateDialogueRequest>
{
    private readonly IThereGameDataService _dataService = dataService;
    
    public async Task Handle(UpdateDialogueRequest request, CancellationToken cancellationToken)
    {
        var dialogue = await _dataService.Dialogues.FindAsync(request.Id);
        if (dialogue == null) {
            return;
        }

        dialogue.Id = request.Id;
        dialogue.Name = request.Name;
        dialogue.PhraseId = request.PhraseId;

        _dataService.Dialogues.Update(dialogue);

        await _dataService.SaveChanges(cancellationToken);
    }
}