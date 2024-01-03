namespace ThereGame.Business.Domain.Dialogue.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;
using System.Diagnostics;

public class GetDialoguesRequestByStudentId : IRequest<DialogueModel[]?>
{
    public Guid Id { get; set; }
}

public class GetDialogues(IThereGameDataService dataService)
    : IRequestHandler<GetDialoguesRequestByStudentId, DialogueModel[]?>
{
    private readonly IThereGameDataService _dataService = dataService;

    public async Task<DialogueModel[]?> Handle(
        GetDialoguesRequestByStudentId request,
        CancellationToken cancellationToken
    )
    {
        var student = await _dataService.Students.FindAsync(request.Id);
        if (student == null)
        {
            return [];
        }

        var fullDialogues = await _dataService.GetFullDialogues(cancellationToken);
        if (fullDialogues == null)
        {
            return [];
        }

        var studentDialogues = fullDialogues
            .Where(dialogue => dialogue.StudentsId.Contains(student.Id))
            .Where(dialogue => dialogue.IsPublished)
            .ToArray()
        ;

        return studentDialogues;
    }
}