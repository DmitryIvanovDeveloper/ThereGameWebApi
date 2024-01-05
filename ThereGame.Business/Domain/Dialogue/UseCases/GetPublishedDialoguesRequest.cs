namespace ThereGame.Business.Domain.Dialogue.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;

public class GetPublishedDialoguesRequest : IRequest<DialogueModel[]>
{
    public Guid Id { get; set; }
}

public class GetPublishedDialogues(IThereGameDataService dataService)
    : IRequestHandler<GetPublishedDialoguesRequest, DialogueModel[]>
{
    private readonly IThereGameDataService _dataService = dataService;

    public async Task<DialogueModel[]> Handle(
        GetPublishedDialoguesRequest request,
        CancellationToken cancellationToken
    ) {
        var dialogues = await _dataService.GetFullDialogues(cancellationToken);
        if (dialogues == null) 
        {
            return [];
        }
        
        return dialogues.Where(dialogue => dialogue.IsPublished).ToArray();
    }
}