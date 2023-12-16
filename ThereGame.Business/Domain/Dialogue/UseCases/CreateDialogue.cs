namespace ThereGame.Business.Domain.Dialogue.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ThereGame.Business.Domain.Phrase;

public class CreateDialogueRequest : IRequest
{
    public required Guid Id { get; set;}
    public required string Name { get; set;}
    public required PhraseModel Phrase { get; set;}
}

public class CreateDialogue(IThereGameDataService dataService) : IRequestHandler<CreateDialogueRequest>
{
    private readonly IThereGameDataService _dataService = dataService;
    
    public async Task Handle(CreateDialogueRequest request, CancellationToken cancellationToken)
    {
        var dialogue = new DialogueModel()
        {
            Id = request.Id,
            Name = request.Name,
            PhraseId = request.Phrase.Id,
            Phrase = request.Phrase
            
        };

        await _dataService.Phrases.AddAsync(dialogue.Phrase, cancellationToken);
        await _dataService.SaveChanges(cancellationToken);

        await _dataService.Dialogues.AddAsync(dialogue, cancellationToken);
        await _dataService.SaveChanges(cancellationToken);
    }
}