namespace ThereGame.Business.Domain.Dialogue.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ThereGame.Business.Domain.Answer;

public class UpdateAnswerRequest : IRequest<DialogueModel?>
{
    public required AnswerModel Answer { get; set; }
}

public class UpdateAnswer(IThereGameDataService dataService) : IRequestHandler<UpdateAnswerRequest, DialogueModel?>
{
    private readonly IThereGameDataService _dataService = dataService;
    
    public async Task<DialogueModel?> Handle(UpdateAnswerRequest request, CancellationToken cancellationToken)
    {
        if(request.Answer == null) {
            return null;
        }

        _dataService.Answers.Update(request.Answer);

        return await _dataService.Dialogues
            .Include(d => d.Phrase)
            .ThenInclude(p => p == null ? null : p.ParentAnswer)
            .ThenInclude(a => a == null ? null : a.ParentPhrase)
            .SingleOrDefaultAsync(d => d.Id == request.Answer.Id)
        ;
    }
}