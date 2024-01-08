namespace ThereGame.Business.Domain.Dialogue.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ThereGame.Business.Domain.Phrase;

public class GetPhraseByIdRequest : IRequest<PhraseModel?>
{
    public Guid Id { get; set; }
}

public class GetPhraseById(IThereGameDataService dataService) : IRequestHandler<GetPhraseByIdRequest, PhraseModel?>
{
    private readonly IThereGameDataService _dataService = dataService;

    public async Task<PhraseModel?> Handle(GetPhraseByIdRequest request, CancellationToken cancellationToken)
    {
        return await _dataService.Phrases.SingleOrDefaultAsync(d => d.Id == request.Id);
    }
}