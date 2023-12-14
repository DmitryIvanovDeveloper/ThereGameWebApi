namespace ThereGame.Business.Domain.Dialogue.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetPhraseByIdRequest : IRequest<DialogueModel?>
{
    public Guid Id { get; set; }
}

public class GetPhraseById(IThereGameDataService dataService) : IRequestHandler<GetPhraseByIdRequest, DialogueModel?>
{
    private readonly IThereGameDataService _dataService = dataService;

    public async Task<DialogueModel?> Handle(GetPhraseByIdRequest request, CancellationToken cancellationToken)
    {
        return await _dataService.Dialogues
            .Include(d => d.Phrase)
            .ThenInclude(p => p == null ? null : p.ParentAnswer)
            .ThenInclude(a => a == null ? null : a.ParentPhrase)
            .SingleOrDefaultAsync(d => d.Id == request.Id)
        ;
    }
}