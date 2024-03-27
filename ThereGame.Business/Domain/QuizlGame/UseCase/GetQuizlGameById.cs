namespace ThereGame.Business.Domain.QuizlGame.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetQuizlGameByIdRequest : IRequest<List<QuizlGameModel>>
{
    public required List<Guid> Ids { get; set; }
}

public class GetQuizlGameById(IThereGameDataService dataService) : IRequestHandler<GetQuizlGameByIdRequest, List<QuizlGameModel>>
{
    private readonly IThereGameDataService _dataService = dataService;

    public async Task<List<QuizlGameModel>> Handle(GetQuizlGameByIdRequest request, CancellationToken cancellationToken)
    {
        if (request.Ids.Count == 0)
        {
            return  await _dataService.QuizlGame.ToListAsync(cancellationToken);
        }

        return await _dataService.QuizlGame
            .Where(w => request.Ids.Contains(w.Id))
            .ToListAsync(cancellationToken)
        ;
    }
}