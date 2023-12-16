namespace ThereGame.Business.Domain.Dialogue.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;

public class GetDialoguesRequest : IRequest<DialogueModel[]?>
{
}

public class GetDialogues(IThereGameDataService dataService)
    : IRequestHandler<GetDialoguesRequest, DialogueModel[]?>
{
    private readonly IThereGameDataService _dataService = dataService;

    public async Task<DialogueModel[]?> Handle(
        GetDialoguesRequest request,
        CancellationToken cancellationToken
    ) {
        return await _dataService.GetFullDialogues(cancellationToken);
    }
}