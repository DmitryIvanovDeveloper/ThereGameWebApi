namespace ThereGame.Business.Domain.QuizlGameStatistic.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;

public class CreateQuizlGameStatisticRequest : IRequest
{
    public required QuizlGameStatisticModel QuizlGameStatistic { get; set; }
}

public class CreateQuizlGameStatistic(IThereGameDataService dataService) : IRequestHandler<CreateQuizlGameStatisticRequest>
{
    private readonly IThereGameDataService _dataService = dataService;
    
    public async Task Handle(CreateQuizlGameStatisticRequest request, CancellationToken cancellationToken)
    {
        await _dataService.QuizlGameStatistics.AddAsync(request.QuizlGameStatistic, cancellationToken);
        await _dataService.SaveChanges(cancellationToken);
    }
}