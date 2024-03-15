namespace ThereGame.Api.Domain.StudentDialogueStatistic.Queries;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Business.Domain.Word.UseCases;

public static class GetWordsQueriesApi
{
    public static async Task<IResult> Handler(
        [FromServices] IMediator mediator
    ) {
        var words = await mediator.Send(new GetWordsByIdRequest());
        if (words.Count == 0)
        {
            return TypedResults.NoContent();
        }

        return TypedResults.Ok(words);
    }
}
