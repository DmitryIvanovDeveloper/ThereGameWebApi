namespace ThereGame.Business.Domain.Dialogue.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;
using ThereGame.Business.Domain.Student;

public class UpdateDialogueRequest : IRequest
{
    public required Guid Id { get; set;}
    public required string Name { get; set; }
    public required Guid LevelId { get; set; }
    public required Guid TeacherId { get; set; }
    public required bool IsPublished { get; set; }
    public required List<StudentModel> Students { get; set; }
    public required bool IsVoiceSelected { get; set; }
    public required Guid PhraseId { get; set; }
}

public class UpdateDialogue(IThereGameDataService dataService) : IRequestHandler<UpdateDialogueRequest>
{
    private readonly IThereGameDataService _dataService = dataService;
    
    public async Task Handle(UpdateDialogueRequest request, CancellationToken cancellationToken)
    {
        var dialogue = new DialogueModel()
        {
            IsVoiceSelected = request.IsVoiceSelected,
            Id = request.Id,
            IsPublished = request.IsPublished,
            TeacherId = request.TeacherId,
            LevelId = request.LevelId,
            Name = request.Name,
            PhraseId = request.PhraseId,
            Students = request.Students,
        };

        _dataService.Dialogues.Update(dialogue);

        await _dataService.SaveChanges(cancellationToken);
    }
}