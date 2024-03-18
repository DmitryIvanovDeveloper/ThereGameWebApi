namespace ThereGame.Api.Domain.Answer.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Business.Domain.QuizlGame.UseCases;

public static class GetQuizlGameByWordIdQueriesApi
{
    public static async Task<IResult> Handler(
        [FromQuery] Guid Id,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    ) {
        
        var quizlGame = await mediator.Send(new GetQuizlGameByIdRequest() {
            Id = Id
        });
        
        if (quizlGame == null)
        {
            return TypedResults.NoContent();
        }
    
        return TypedResults.Ok(quizlGame);
    }
}
