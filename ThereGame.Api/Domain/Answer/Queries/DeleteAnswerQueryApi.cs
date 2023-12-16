namespace ThereGame.Api.Domain.Answer.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Business.Domain.Dialogue.UseCases;

public static class DeleteAnswerQueryApi
{
    public static async Task<IResult> Handler(
        [FromBody] Guid id,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    ) {
        await mediator.Send(new DeleteAnswerRequest() {
            Id = id
        });

        return TypedResults.Ok();
    }
}
