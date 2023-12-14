namespace ThereGame.Business.Domain.Dialogue.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ThereGame.Business.Domain.Phrase;

public class CreateDialogueRequest : IRequest<DialogueModel?>
{
    public required Guid Id { get; set;}
    public required string Name { get; set;}
    public required Guid PhraseId { get; set;}
}

public class CreateDialogue(IThereGameDataService dataService) : IRequestHandler<CreateDialogueRequest, DialogueModel?>
{
    private readonly IThereGameDataService _dataService = dataService;
    
    public async Task<DialogueModel?> Handle(CreateDialogueRequest request, CancellationToken cancellationToken)
    {
        var phrase = new PhraseModel(){
            Id = request.Id
        };

        var dialogue = new DialogueModel()
        {
            Id = request.Id,
            Name = request.Name,
            PhraseId = request.PhraseId
        };

        await _dataService.Phrases.AddAsync(phrase, cancellationToken);
        await _dataService.SaveChanges(cancellationToken);

        await _dataService.Dialogues.AddAsync(dialogue, cancellationToken);
        await _dataService.SaveChanges(cancellationToken);
        
        return await _dataService.Dialogues
            .Include(d => d.Phrase)
            .ThenInclude(p => p == null ? null : p.ParentAnswer)
            .ThenInclude(a => a == null ? null : a.ParentPhrase)
            .SingleOrDefaultAsync(d => d.Id == dialogue.Id)
        ;
    }
}