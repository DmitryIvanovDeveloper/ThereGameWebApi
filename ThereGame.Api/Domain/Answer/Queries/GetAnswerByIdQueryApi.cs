namespace ThereGame.Api.Domain.Answer.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Business.Domain.Dialogue.UseCases;

public static class GetAnswerByIdQueryApi
{
    public static async Task<IResult> Handler(
        [FromRoute] Guid id,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    )
    {
        var phrase = await mediator.Send(new GetAnswerByIdRequest() {
            Id = id
        });
        
        if (phrase == null)
        {
            return TypedResults.NoContent();
        }

        return TypedResults.Ok(phrase);
    }
}
