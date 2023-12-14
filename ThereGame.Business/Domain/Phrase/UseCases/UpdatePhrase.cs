namespace ThereGame.Business.Domain.Dialogue.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ThereGame.Business.Domain.Phrase;

public class UpdatePhraseRequest : IRequest<DialogueModel?>
{
    public required PhraseModel Phrase { get; set; }
}

public class UpdatePhrase(IThereGameDataService dataService) : IRequestHandler<UpdatePhraseRequest, DialogueModel?>
{
    private readonly IThereGameDataService _dataService = dataService;
    
    public async Task<DialogueModel?> Handle(UpdatePhraseRequest request, CancellationToken cancellationToken)
    {
        if(request.Phrase == null) {
            return null;
        }

        return await _dataService.Dialogues
            .Include(d => d.Phrase)
            .ThenInclude(p => p == null ? null : p.ParentAnswer)
            .ThenInclude(a => a == null ? null : a.ParentPhrase)
            .SingleOrDefaultAsync(d => d.Id == request.Phrase.Id)
        ;
    }
}