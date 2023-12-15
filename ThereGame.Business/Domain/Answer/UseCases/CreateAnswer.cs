namespace ThereGame.Business.Domain.Dialogue.UseCases;

using MediatR;
using ThereGame.Business.Domain.Answer;
using ThereGame.Business.Util.Services;

public class CreateAnswerRequest : IRequest
{
    public required AnswerModel Answer { get; set; }
}

public class CreateAnswer(IThereGameDataService dataService) : IRequestHandler<CreateAnswerRequest>
{
    private readonly IThereGameDataService _dataService = dataService;

    public async Task Handle(CreateAnswerRequest request, CancellationToken cancellationToken)
    {
        if (request.Answer == null)
        {
            return;
        }
        
        await _dataService.Answers.AddAsync(request.Answer, cancellationToken);
        
        await _dataService.SaveChanges(cancellationToken);
    }
}