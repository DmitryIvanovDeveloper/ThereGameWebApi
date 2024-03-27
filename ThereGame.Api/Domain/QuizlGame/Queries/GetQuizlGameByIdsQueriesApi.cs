namespace ThereGame.Api.Domain.Answer.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ThereGame.Business.Domain.QuizlGame.UseCases;

public static class GetQuizlGameByIdsQueriesApi
{
    public static async Task<IResult> Handler(
        [FromQuery] string Ids,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    ) {
        
        var quizlGame = await mediator.Send(new GetQuizlGameByIdRequest() {
            Ids = JsonConvert.DeserializeObject<List<Guid>>(Ids)
        });
        
        if (quizlGame == null)
        {
            return TypedResults.NoContent();
        }
    
        return TypedResults.Ok(quizlGame);
    }
}
