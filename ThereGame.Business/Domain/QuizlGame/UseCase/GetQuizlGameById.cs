namespace ThereGame.Business.Domain.QuizlGame.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;

public class GetQuizlGameByIdRequest : IRequest<QuizlGameModel?>
{
    public required Guid Id { get; set; }
}

public class GetQuizlGameById(IThereGameDataService dataService) : IRequestHandler<GetQuizlGameByIdRequest, QuizlGameModel?>
{
    private readonly IThereGameDataService _dataService = dataService;

    public async Task<QuizlGameModel?> Handle(GetQuizlGameByIdRequest request, CancellationToken cancellationToken)
    {
       return  await _dataService.QuizlGame.FindAsync(request.Id, cancellationToken);
    
    }
}