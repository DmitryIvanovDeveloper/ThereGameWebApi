namespace ThereGame.Api.Domain.QuizlGame.Queries;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Business.Domain.QuizlGame.UseCases;

public static class DeleteQuizlGameQueriesApi
{
    public static async Task<IResult> Handler(
        [FromHeader(Name = "X-THEREGAME-AUTH")] Guid id,
        [FromQuery] Guid Id,
        [FromServices] IMediator mediator
    ) {
        await mediator.Send(new DeleteQuizlGameRequest() 
        {
            Id = Id
        });

        return TypedResults.Ok();
    }
}
