namespace ThereGame.Api.Domain.Answer.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Business.Domain.Dialogue.UseCases;

public static class GetDialoguesQueryApi
{
    public static async Task<IResult> Handler(
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    ) {
        var dialogues = await mediator.Send(new GetDialoguesRequest());
        if (dialogues == null)
        {
            return TypedResults.NoContent();
        }

        return TypedResults.Ok(dialogues);
    }
}
