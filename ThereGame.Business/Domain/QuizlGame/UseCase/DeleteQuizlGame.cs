namespace ThereGame.Business.Domain.QuizlGame.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;

public class DeleteQuizlGameRequest : IRequest
{
    public required Guid Id { get; set; }
}

public class DeleteQuizlGame(IThereGameDataService dataService) : IRequestHandler<DeleteQuizlGameRequest>
{
    private readonly IThereGameDataService _dataService = dataService;

    public async Task Handle(DeleteQuizlGameRequest request, CancellationToken cancellationToken)
    {
        var quizleGame = await _dataService.QuizlGame.FindAsync(request.Id, cancellationToken);
        if (quizleGame != null)
        {
            _dataService.QuizlGame.Remove(quizleGame);
        }

        var expectedWord = await  _dataService.Words.FindAsync(quizleGame.HiddenWordId);
        if (expectedWord != null) {
            expectedWord.QuizlGamesId.Remove(request.Id);
        }

        await _dataService.SaveChanges(cancellationToken);
    }
}