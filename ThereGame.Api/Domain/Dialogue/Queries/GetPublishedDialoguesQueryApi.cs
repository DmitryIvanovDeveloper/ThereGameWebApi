namespace ThereGame.Api.Domain.Answer.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Api.Util.Mappings;
using ThereGame.Business.Domain.Dialogue.UseCases;

public static class GetPublishedDialoguesQueryApi
{
    public static async Task<IResult> Handler(
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    ) {
        var dialogue = await mediator.Send(new GetPublishedDialoguesRequest());
        if (dialogue.Count() == 0)
        {
            return TypedResults.NoContent();
        }

        var response = DialogueMapping.Response(dialogue);

        return TypedResults.Ok(response);
    }
}
