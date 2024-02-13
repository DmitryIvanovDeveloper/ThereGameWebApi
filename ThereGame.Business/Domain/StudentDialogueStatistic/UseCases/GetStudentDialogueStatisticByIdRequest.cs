namespace ThereGame.Business.Domain.StudentDialogueStatistic.UseCases;

using MediatR;
using Microsoft.EntityFrameworkCore;
using ThereGame.Business.Util.Services;

public class GetStudentDialogueStatisticByIdRequest : IRequest<StudentDialogueStatisticModel[]?>
{
    public required Guid Id { get; set; }
}

public class GetStudentDialogueStatistic(IThereGameDataService dataService) : IRequestHandler<GetStudentDialogueStatisticByIdRequest, StudentDialogueStatisticModel[]?>
{
    private readonly IThereGameDataService _dataService = dataService;
    
    public async Task<StudentDialogueStatisticModel[]?> Handle(GetStudentDialogueStatisticByIdRequest request, CancellationToken cancellationToken)
    {
        var student = await _dataService.Students.FindAsync(request.Id);
        if (student == null)
        {
            return null;
        }
        
        return await _dataService.StudentDialoguesStatistics
            .Include(ds => ds.DialogueHistories)
            .Where(ds => ds.StudentId == request.Id)
            .ToArrayAsync(cancellationToken)
        ;
    }
}