namespace ThereGame.Api.Domain.Answer.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Business.Domain.Dialogue.UseCases;

public static class UpdatePhraseQueryApi
{
    public static async Task<IResult> Handler(
        [FromBody] PhraseDto phrase,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    )
    {
        var updatedPhrase = await mediator.Send(new UpdatePhraseRequest() {
            Phrase = DialogueMapping.MapDtoToModel(phrase)
        });
        if (updatedPhrase == null)
        {
            return TypedResults.NoContent();
        }

        return TypedResults.Ok(updatedPhrase);
    }
}
