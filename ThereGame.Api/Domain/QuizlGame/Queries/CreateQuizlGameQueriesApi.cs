namespace ThereGame.Api.Domain.QuizlGame.Queries;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Business.Domain.QuizlGame.UseCases;

public static class CreateQuizlGameQueriesApi
{
    public static async Task<IResult> Handler(
        [FromHeader(Name = "X-THEREGAME-AUTH")] Guid id,
        [FromBody] QuizlGameDto QuizlGame,
        [FromServices] IMediator mediator
    ) {
        await mediator.Send(new CreateQuizlGameRequest() 
        {
            QuizlGame = QuizleGameMapper.Map(QuizlGame)
        });

        return TypedResults.Ok();
    }
}
