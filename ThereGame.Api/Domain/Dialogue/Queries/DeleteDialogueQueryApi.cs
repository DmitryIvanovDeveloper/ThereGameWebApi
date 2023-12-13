namespace ThereGame.Api.Domain.Answer.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Business.Domain.Dialogue.UseCases;

public static class DeleteDialogueQueryApi
{
    public static async Task<IResult> Handler(
        [FromRoute] Guid id,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    )
    {
        var dialogue = await mediator.Send(new DeleteDialogueRequest() {
            Id = id
        });
        
        if (dialogue == null)
        {
            return TypedResults.NoContent();
        }

        return TypedResults.Ok(dialogue);
    }
}
