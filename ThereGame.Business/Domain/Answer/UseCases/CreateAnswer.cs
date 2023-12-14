namespace ThereGame.Business.Domain.Dialogue.UseCases;

using MediatR;
using Microsoft.EntityFrameworkCore;
using ThereGame.Business.Domain.Answer;
using ThereGame.Business.Util.Services;

public class CreateAnswerRequest : IRequest<DialogueModel?>
{
    public required AnswerModel Answer { get; set; }
}

public class CreateAnswer(IThereGameDataService dataService) : IRequestHandler<CreateAnswerRequest, DialogueModel?>
{
    private readonly IThereGameDataService _dataService = dataService;

    public async Task<DialogueModel?> Handle(CreateAnswerRequest request, CancellationToken cancellationToken)
    {
        return await _dataService.Dialogues
            .Include(d => d.Phrase)
            .ThenInclude(p => p == null ? null : p.ParentAnswer)
            .ThenInclude(a => a == null ? null : a.ParentPhrase)
            .SingleOrDefaultAsync(d => d.Id == request.Answer.Id)
        ;
    }
}