namespace ThereGame.Business.Domain.Dialogue.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;

public class UpdateDialogueRequest : IRequest
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required Guid LevelId { get; set; }
    public required Guid TeacherId { get; set; }
    public required bool IsPublished { get; set; }
    public required List<Guid> StudentsId { get; set; } = new List<Guid>();
    public required List<Guid> VocbularyWordsId { get; set; } = new List<Guid>();
    public required string VoiceSettings { get; set; }
    public required Guid PhraseId { get; set; }
}

public class UpdateDialogue(IThereGameDataService dataService) : IRequestHandler<UpdateDialogueRequest>
{
    private readonly IThereGameDataService _dataService = dataService;

    public async Task Handle(UpdateDialogueRequest request, CancellationToken cancellationToken)
    {
        var dialogue = new DialogueModel()
        {
            VoiceSettings = request.VoiceSettings,
            Id = request.Id,
            IsPublished = request.IsPublished,
            TeacherId = request.TeacherId,
            LevelId = request.LevelId,
            Name = request.Name,
            PhraseId = request.PhraseId,
            StudentsId = request.StudentsId,
            VocabularyWordsId = request.VocbularyWordsId,
        };

        _dataService.Dialogues.Update(dialogue);

        await _dataService.SaveChanges(cancellationToken);
    }
}