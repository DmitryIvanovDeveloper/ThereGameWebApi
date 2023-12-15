namespace ThereGame.Business.Domain.Dialogue.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class DeleteAnswerRequest : IRequest<DialogueModel?>
{
    public Guid Id { get; set; }
}

public class DeleteAnswer(IThereGameDataService dataService) : IRequestHandler<DeleteAnswerRequest, DialogueModel?>
{
    private readonly IThereGameDataService _dataService = dataService;
    
    public async Task<DialogueModel?> Handle(DeleteAnswerRequest request, CancellationToken cancellationToken)
    {
        var answer = _dataService.Answers.Find(request.Id);
        if (answer == null) {
            return null;
        }

        _dataService.Answers.Remove(answer);

        await _dataService.SaveChanges(cancellationToken);
        
        return await _dataService.Dialogues
            .Include(d => d.Phrase)
            .ThenInclude(p => p == null ? null : p.ParentAnswer)
            .ThenInclude(a => a == null ? null : a.ParentPhrase)
            .SingleOrDefaultAsync(d => d.Id == request.Id)
        ;
    }
}