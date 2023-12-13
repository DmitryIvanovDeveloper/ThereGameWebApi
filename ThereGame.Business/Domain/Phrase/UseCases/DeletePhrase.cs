namespace ThereGame.Business.Domain.Dialogue.UseCases;

using Inspirer.Business.Util.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class DeletePhraseRequest : IRequest<DialogueModel?>
{
    public Guid Id { get; set; }
}

public class DeletePhrase(IThereGameDataService dataService) : IRequestHandler<DeletePhraseRequest, DialogueModel?>
{
    private readonly IThereGameDataService _dataService = dataService;
    
    public async Task<DialogueModel?> Handle(DeletePhraseRequest request, CancellationToken cancellationToken)
    {

        return await _dataService.Dialogues
            .Include(d => d.Phrase)
            .ThenInclude(p => p == null ? null : p.ParentAnswer)
            .ThenInclude(a => a == null ? null : a.ParentPhrase)
            .SingleOrDefaultAsync(d => d.Id == request.Id)
        ;
    }
}