namespace ThereGame.Business.Domain.Dialogue.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;

public class DeletePhraseRequest : IRequest
{
    public Guid Id { get; set; }
}

public class DeletePhrase(IThereGameDataService dataService) : IRequestHandler<DeletePhraseRequest>
{
    private readonly IThereGameDataService _dataService = dataService;
    
    public async Task Handle(DeletePhraseRequest request, CancellationToken cancellationToken)
    {
        await _dataService.RemovePhraseCascade(request.Id);
        await _dataService.SaveChanges(cancellationToken);
    }
}