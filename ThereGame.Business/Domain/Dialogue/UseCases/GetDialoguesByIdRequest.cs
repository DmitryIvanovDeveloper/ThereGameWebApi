namespace ThereGame.Business.Domain.Dialogue.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;

public class GetDialoguesByIdRequest : IRequest<DialogueModel[]?>
{
    public Guid Id { get; set; }
}

public class GetDialogues(IThereGameDataService dataService)
    : IRequestHandler<GetDialoguesByIdRequest, DialogueModel[]?>
{
    private readonly IThereGameDataService _dataService = dataService;

    public async Task<DialogueModel[]?> Handle(
        GetDialoguesByIdRequest request,
        CancellationToken cancellationToken
    )
    {
        var fullDialogues = await _dataService.GetFullDialogues(cancellationToken);
        if (fullDialogues != null)
        {
            return [];
        }
        
        var student = await _dataService.Students.FindAsync(request.Id);
        if (student != null)
        {
            return fullDialogues
                .Where(dialogue => dialogue.StudentsId.Contains(student.Id))
                .ToArray()
            ;
        }

        var teacher = await _dataService.Teachers.FindAsync(request.Id);
        if (student != null)
        {
            return fullDialogues
                .Where(dialogue => dialogue.TeacherId == teacher.Id)
                .ToArray()
            ;
        }

        return [];
    }
}