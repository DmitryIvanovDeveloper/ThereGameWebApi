namespace ThereGame.Business.Domain.QuizlGame.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;

public class UpdateQuizlGameRequest : IRequest
{
    public required QuizlGameModel QuizlGame { get; set; }
}

public class UpdateQuizlGame(IThereGameDataService dataService) : IRequestHandler<UpdateQuizlGameRequest>
{
    private readonly IThereGameDataService _dataService = dataService;

    public async Task Handle(UpdateQuizlGameRequest request, CancellationToken cancellationToken)
    {
        var quizleGame = await _dataService.QuizlGame.FindAsync(request.QuizlGame.Id, cancellationToken);
        if (quizleGame == null)
        {
            return;
        }

        var expectedPreviousWord = await _dataService.Words.FindAsync(quizleGame.HiddenWordId);
        if (expectedPreviousWord == null) {
            return;
        }

        expectedPreviousWord.QuizlGamesId.Remove(quizleGame.Id);
        

        await _dataService.QuizlGame.AddAsync(request.QuizlGame, cancellationToken);

        var expectedWord = await _dataService.Words.FindAsync(request.QuizlGame.HiddenWordId);
        if (expectedWord == null) {
            return;
        }

        expectedWord.QuizlGamesId.Add(request.QuizlGame.Id);

        await _dataService.SaveChanges(cancellationToken);
    }
}