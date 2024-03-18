namespace ThereGame.Business.Domain.QuizlGame.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;

public class CreateQuizlGameRequest : IRequest
{
    public required QuizlGameModel QuizlGame { get; set; }
}

public class CreateQuizlGame(IThereGameDataService dataService) : IRequestHandler<CreateQuizlGameRequest>
{
    private readonly IThereGameDataService _dataService = dataService;

    public async Task Handle(CreateQuizlGameRequest request, CancellationToken cancellationToken)
    {
        var quizleGame = await _dataService.QuizlGame.FindAsync(request.QuizlGame.Id, cancellationToken);
        if (quizleGame != null)
        {
            return;
        }



        await _dataService.QuizlGame.AddAsync(request.QuizlGame, cancellationToken);

        var expectedWord = await _dataService.Words.FindAsync(request.QuizlGame.HiddenWordId);
        Console.WriteLine($"========={expectedWord == null}==========");

        if (expectedWord == null) {
            return;
        }

        expectedWord.QuizlGamesId.Add(request.QuizlGame.Id);

        await _dataService.SaveChanges(cancellationToken);
    }
}