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
        var dialogue = new DialogueModel()
        {
            Id = request.Id,
            Name = request.Name,
            PhraseId = request.PhraseId
        };

        _dataService.Dialogues.Update(dialogue);

        await _dataService.SaveChanges(cancellationToken);
    }
}