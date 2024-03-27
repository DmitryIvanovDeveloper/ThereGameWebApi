namespace ThereGame.Business.Domain.QuizlGameStatistic.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;

public class CreateTranslateWordsGameStatisticRequest : IRequest
{
    public required TranslateWordsGameStatisticModel TranslateWordsGameStatistic { get; set; }
}

public class CreateTranslateWordsGameStatistic(IThereGameDataService dataService) : IRequestHandler<CreateTranslateWordsGameStatisticRequest>
{
    private readonly IThereGameDataService _dataService = dataService;
    
    public async Task Handle(CreateTranslateWordsGameStatisticRequest request, CancellationToken cancellationToken)
    {
        await _dataService.TranslateWordsGameStatistics.AddAsync(request.TranslateWordsGameStatistic, cancellationToken);
        await _dataService.SaveChanges(cancellationToken);
    }
}