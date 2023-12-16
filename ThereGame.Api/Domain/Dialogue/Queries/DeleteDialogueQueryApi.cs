namespace ThereGame.Api.Domain.Answer.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Business.Domain.Dialogue.UseCases;

public static class DeleteDialogueQueryApi
{
    public static async Task<IResult> Handler(
        [FromBody] Guid id,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    ) {
        await mediator.Send(new DeleteDialogueRequest() {
            Id = id
        });

        return TypedResults.Ok();
    }
}
