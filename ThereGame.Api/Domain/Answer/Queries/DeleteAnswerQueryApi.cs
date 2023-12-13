namespace ThereGame.Api.Domain.Answer.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Business.Domain.Dialogue.UseCases;

public static class DeleteAnswerQueryApi
{
    public static async Task<IResult> Handler(
        [FromRoute] Guid id,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    )
    {
        var updatedAnswer = await mediator.Send(new DeleteAnswerRequest() {
            Id = id
        });
        
        if (updatedAnswer == null)
        {
            return TypedResults.NoContent();
        }

        return TypedResults.Ok(updatedAnswer);
    }
}
