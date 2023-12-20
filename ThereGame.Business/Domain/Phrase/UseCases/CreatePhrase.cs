namespace ThereGame.Business.Domain.Dialogue.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ThereGame.Business.Domain.Phrase;

public class CreatePhraseRequest : IRequest
{
    public required PhraseModel Phrase { get; set; }
}

public class CreatePhrase(IThereGameDataService dataService) : IRequestHandler<CreatePhraseRequest>
{
    private readonly IThereGameDataService _dataService = dataService;

    public async Task Handle(CreatePhraseRequest request, CancellationToken cancellationToken)
    {
        if (request.Phrase == null)
        {
            return;
        }
        
        await _dataService.Phrases.AddAsync(request.Phrase, cancellationToken);
        await _dataService.SaveChanges(cancellationToken);
    }
}