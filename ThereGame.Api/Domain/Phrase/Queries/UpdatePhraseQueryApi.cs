namespace ThereGame.Api.Domain.Answer.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Api.Domain.Phrase.Dtos;
using ThereGame.Api.Util.Mappings;
using ThereGame.Business.Domain.Dialogue.UseCases;

public static class UpdatePhraseQueryApi
{
    public static async Task<IResult> Handler(
        [FromBody] PhraseUpdateRequestApiDto phraseUpdateRequestApiDto,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    ) {
        await mediator.Send(new UpdatePhraseRequest() {
            Phrase = DialogueMapping.Request(phraseUpdateRequestApiDto)
        });
        
        return TypedResults.Ok();
    }
}
