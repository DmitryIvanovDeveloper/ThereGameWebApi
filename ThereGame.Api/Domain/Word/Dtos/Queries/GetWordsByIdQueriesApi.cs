namespace ThereGame.Api.Domain.StudentDialogueStatistic.Queries;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ThereGame.Business.Domain.Word.UseCases;

public static class GetWordsByIdQueriesApi
{
    public static async Task<IResult> Handler(
        [FromQuery] string ids,
        [FromServices] IMediator mediator
    ) {
        
        var words = await mediator.Send(new GetWordsByIdRequest() {
            Ids =  JsonConvert.DeserializeObject<List<Guid>>(ids)
        });

        if (words.Count == 0)
        {
            return TypedResults.NoContent();
        }

        return TypedResults.Ok(words);
    }
}
