namespace ThereGame.Business.Domain.Dialogue.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetDialogueByIdRequest : IRequest<DialogueModel?>
{
    public Guid Id { get; set; }
}

public class GetDialogueById(IThereGameDataService dataService) : IRequestHandler<GetDialogueByIdRequest, DialogueModel?>
{
    private readonly IThereGameDataService _dataService = dataService;

    public async Task<DialogueModel?> Handle(GetDialogueByIdRequest request, CancellationToken cancellationToken)
    {
        return await _dataService.Dialogues
            .Include(d => d.Phrase)
            .ThenInclude(p => p == null ? null : p.ParentAnswer)
            .ThenInclude(a => a == null ? null : a.ParentPhrase)
            .SingleOrDefaultAsync(d => d.Id == request.Id)
        ;
    }
}