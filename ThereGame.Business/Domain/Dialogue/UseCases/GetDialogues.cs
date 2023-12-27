namespace ThereGame.Business.Domain.Dialogue.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

public class GetDialoguesRequest : IRequest<DialogueModel[]?>
{
    public Guid Id { get; set; }
}

public class GetDialogues(IThereGameDataService dataService)
    : IRequestHandler<GetDialoguesRequest, DialogueModel[]?>
{
    private readonly IThereGameDataService _dataService = dataService;

    public async Task<DialogueModel[]?> Handle(
        GetDialoguesRequest request,
        CancellationToken cancellationToken
    )
    {
        var fullDialogues = await _dataService.GetFullDialogues(cancellationToken);
        if (fullDialogues == null)
        {
            return [];
        }
      
        return fullDialogues.ToArray();
    }
}