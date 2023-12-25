namespace ThereGame.Business.Domain.Dialogue.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;

public class DeleteAnswerRequest : IRequest
{
    public Guid Id { get; set; }
}

public class DeleteAnswer(IThereGameDataService dataService) : IRequestHandler<DeleteAnswerRequest>
{
    private readonly IThereGameDataService _dataService = dataService;

    
    public async Task Handle(DeleteAnswerRequest request, CancellationToken cancellationToken)
    {
        var answer = _dataService.Answers.Find(request.Id);
        if (answer == null) {
            return;
        }

        _dataService.Answers.RemoveRange(answer);

        await _dataService.SaveChanges(cancellationToken);
    }
}