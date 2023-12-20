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
        
        _dataService.Translates.RemoveRange(
            await _dataService.Translates
                .Where(t => t.AnswerParentId == request.Answer.Id)
                .ToArrayAsync(cancellationToken)
        );
        
        await _dataService.Translates.AddRangeAsync(request.Answer.Translates, cancellationToken);

        _dataService.MistakeExplanations.RemoveRange(
              await _dataService.MistakeExplanations
                .Where(m => m.AnswerParentId == request.Answer.Id)
                .ToArrayAsync(cancellationToken)
        );

        await _dataService.MistakeExplanations.AddRangeAsync(request.Answer.MistakeExplanations, cancellationToken);

        _dataService.Answers.Update(request.Answer);

        await _dataService.SaveChanges(cancellationToken);
    }
}