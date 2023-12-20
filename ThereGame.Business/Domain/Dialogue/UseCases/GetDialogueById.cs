namespace ThereGame.Business.Domain.Dialogue.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;

public class GetDialogueByIdRequest : IRequest<DialogueModel?>
{
    public Guid Id { get; set; }
}

public class GetDialogueById(IThereGameDataService dataService)
    : IRequestHandler<GetDialogueByIdRequest, DialogueModel?>
{
    private readonly IThereGameDataService _dataService = dataService;

    public async Task<DialogueModel?> Handle(
        GetDialogueByIdRequest request,
        CancellationToken cancellationToken
    ) {
        return await _dataService.GetFullDialogueById(
            request.Id,
            cancellationToken
        );
    }
}