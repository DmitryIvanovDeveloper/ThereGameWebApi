namespace ThereGame.Api.Domain.Answer.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Api.Util.Mappings;
using ThereGame.Business.Domain.Dialogue.UseCases;

public static class GetAnswerByIdQueryApi
{
    public static async Task<IResult> Handler(
        [FromRoute] Guid id,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    ) {
        var answer = await mediator.Send(new GetAnswerByIdRequest() {
            Id = id
        });
        
        if (answer == null)
        {
            return TypedResults.NoContent();
        }

        var response = DialogueMapping.Response(answer);

        return TypedResults.Ok(response);
    }
}
