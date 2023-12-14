namespace ThereGame.Business.Domain.Dialogue.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class UpdateDialogueRequest : IRequest<DialogueModel?>
{
    public required DialogueModel Dialogue { get; set; }
}

public class UpdateDialogue(IThereGameDataService dataService) : IRequestHandler<UpdateDialogueRequest, DialogueModel?>
{
    private readonly IThereGameDataService _dataService = dataService;
    
    public async Task<DialogueModel?> Handle(UpdateDialogueRequest request, CancellationToken cancellationToken)
    {
        if(request.Dialogue == null) {
            return null;
        }

        return await _dataService.Dialogues
            .Include(d => d.Phrase)
            .ThenInclude(p => p == null ? null : p.ParentAnswer)
            .ThenInclude(a => a == null ? null : a.ParentPhrase)
            .SingleOrDefaultAsync(d => d.Id == request.Dialogue.Id)
        ;
    }
}