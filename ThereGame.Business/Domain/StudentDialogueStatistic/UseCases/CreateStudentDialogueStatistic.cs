namespace ThereGame.Business.Domain.StudentDialogueStatistic.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;

public class CreateStudentDialogueStatisticRequest : IRequest
{
    public required StudentDialogueStatisticModel StudentDialogueStatistic { get; set; }
}

public class CreateStudentDialogueStatistic(IThereGameDataService dataService) : IRequestHandler<CreateStudentDialogueStatisticRequest>
{
    private readonly IThereGameDataService _dataService = dataService;
    
    public async Task Handle(CreateStudentDialogueStatisticRequest request, CancellationToken cancellationToken)
    {
        var student = await _dataService.Students.FindAsync(request.StudentDialogueStatistic.StudentId);
        if (student == null)
        {
            return;
        }
        await _dataService.StudentDialoguesStatistics.AddAsync(request.StudentDialogueStatistic);
        await _dataService.DialogueHistories.AddRangeAsync(request.StudentDialogueStatistic.DialogueHistories);
        await _dataService.SaveChanges(cancellationToken);
    }
}