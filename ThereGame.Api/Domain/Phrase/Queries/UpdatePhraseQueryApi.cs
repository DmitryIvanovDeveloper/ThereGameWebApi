namespace ThereGame.Api.Domain.Answer.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Api.Util.Mappings;
using ThereGame.Business.Domain.Dialogue.UseCases;

public static class UpdatePhraseQueryApi
{
    public static async Task<IResult> Handler(
        [FromBody] PhraseUpdateRequestApiDto phrase,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    ) {
        await mediator.Send(new UpdatePhraseRequest() {
            Phrase = DialogueMapping.Request(phrase)
        });

        return TypedResults.Ok();
    }
}
