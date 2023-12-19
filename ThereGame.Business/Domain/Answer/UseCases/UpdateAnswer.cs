namespace ThereGame.Business.Domain.Dialogue.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;
using ThereGame.Business.Domain.Answer;
using Microsoft.EntityFrameworkCore;

public class UpdateAnswerRequest : IRequest
{
    public required AnswerModel Answer { get; set; }
}

public class UpdateAnswer(IThereGameDataService dataService) : IRequestHandler<UpdateAnswerRequest>
{
    private readonly IThereGameDataService _dataService = dataService;
    
    public async Task Handle(UpdateAnswerRequest request, CancellationToken cancellationToken)
    {
        if(request.Answer == null) {
            return;
        }

        _dataService.Translates.RemoveRange(_dataService.Translates);
        _dataService.Translates.AddRange(request.Answer.Translates);

        _dataService.MistakeExplanations.RemoveRange(_dataService.MistakeExplanations);
        _dataService.MistakeExplanations.AddRange(request.Answer.MistakeExplanations);

        _dataService.Answers.Update(request.Answer);

        await _dataService.SaveChanges(cancellationToken);
    }
}