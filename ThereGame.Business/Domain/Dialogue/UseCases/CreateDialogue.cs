namespace ThereGame.Business.Domain.Dialogue.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;
using ThereGame.Business.Domain.Phrase;

public class CreateDialogueRequest : IRequest
{
    public required Guid Id { get; set; }
    public required Guid LevelId { get; set; }
    public required Guid TeacherId { get; set; }
    public required string Name { get; set; }
    public required bool IsPublished { get; set; }
    public required bool IsVoiceSelected { get; set; }
    public required PhraseModel Phrase { get; set; }
    public required List<Guid> StudentsId { get; set; } = new List<Guid>();
}

public class CreateDialogue(IThereGameDataService dataService, IMediator mediator) : IRequestHandler<CreateDialogueRequest>
{
    private readonly IThereGameDataService _dataService = dataService;
    private readonly IMediator _mediator = mediator;
    
    public async Task Handle(CreateDialogueRequest request, CancellationToken cancellationToken)
    {
        var dialogue = new DialogueModel()
        {
            Id = request.Id,
            Name = request.Name,
            LevelId = request.LevelId,
            PhraseId = request.Phrase.Id,
            TeacherId = request.TeacherId,
            IsPublished = request.IsPublished,
            IsVoiceSelected = request.IsVoiceSelected,
            StudentsId = request.StudentsId
        };

        await _mediator.Send(new CreatePhraseRequest
        {
            Phrase = request.Phrase,
        });

        await _dataService.Dialogues.AddAsync(dialogue, cancellationToken);
        await _dataService.SaveChanges(cancellationToken);
    }
}