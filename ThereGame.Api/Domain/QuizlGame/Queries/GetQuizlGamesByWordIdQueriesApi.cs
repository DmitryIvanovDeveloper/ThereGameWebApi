namespace ThereGame.Api.Domain.Answer.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ThereGame.Business.Domain.QuizlGame.UseCases;

public static class GetQuizlGamesByWordIdQueriesApi
{
    public static async Task<IResult> Handler(
        [FromQuery] Guid id,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    ) {
        
        var quizlGame = await mediator.Send(new GetQuizlGamesByWordIdRequest() {
            Id = id
        });
        
        if (quizlGame == null)
        {
            return TypedResults.NoContent();
        }
    
        return TypedResults.Ok(quizlGame);
    }
}
