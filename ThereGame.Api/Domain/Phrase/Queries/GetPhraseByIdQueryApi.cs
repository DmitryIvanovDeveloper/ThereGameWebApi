namespace ThereGame.Api.Domain.Answer.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Api.Util.Mappings;
using ThereGame.Business.Domain.Dialogue.UseCases;

public static class GetPhraseByIdQueryApi
{
    public static async Task<IResult> Handler(
        [FromRoute] Guid Id,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    ) {
        var phrase = await mediator.Send(new GetPhraseByIdRequest() {
            Id = Id
        });
        
        if (phrase == null)
        {
            return TypedResults.NoContent();
        }

        var response = DialogueMapping.Response(phrase);

        return TypedResults.Ok(response);
    }
}
