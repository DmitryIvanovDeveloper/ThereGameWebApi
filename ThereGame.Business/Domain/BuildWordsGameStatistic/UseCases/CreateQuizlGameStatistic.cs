namespace ThereGame.Business.Domain.QuizlGameStatistic.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;

public class CreateBuildWordsGameStatisticRequest : IRequest
{
    public required BuildWordsGameStatisticModel BuildWordsGameStatistic { get; set; }
}

public class CreateBuildWordsGameStatistic(IThereGameDataService dataService) : IRequestHandler<CreateBuildWordsGameStatisticRequest>
{
    private readonly IThereGameDataService _dataService = dataService;
    
    public async Task Handle(CreateBuildWordsGameStatisticRequest request, CancellationToken cancellationToken)
    {
        await _dataService.BuildWordsGameStatistics.AddAsync(request.BuildWordsGameStatistic, cancellationToken);
        await _dataService.SaveChanges(cancellationToken);
    }
}