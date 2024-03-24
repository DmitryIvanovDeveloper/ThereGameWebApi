namespace ThereGame.Business.Domain.QuizlGame.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetQuizlGamesByWordIdRequest : IRequest<List<QuizlGameModel>>
{
    public required Guid Id { get; set; }
}

public class GetQuizlGamesByWordId(IThereGameDataService dataService) : IRequestHandler<GetQuizlGamesByWordIdRequest, List<QuizlGameModel>>
{
    private readonly IThereGameDataService _dataService = dataService;

    public async Task<List<QuizlGameModel>> Handle(GetQuizlGamesByWordIdRequest request, CancellationToken cancellationToken)
    {
        var expectedWord = await  _dataService.Words.FindAsync(request.Id, cancellationToken);
        if (expectedWord == null) 
        {
            return [];
        }

        Console.WriteLine(expectedWord.Word);

        return await _dataService.QuizlGame
            .Where(quizleGame => expectedWord.QuizlGamesId.Contains(request.Id))
            .ToListAsync(cancellationToken)
        ;
    }
}