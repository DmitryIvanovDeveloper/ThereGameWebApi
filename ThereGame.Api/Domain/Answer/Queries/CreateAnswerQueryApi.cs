namespace ThereGame.Api.Domain.Answer.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Api.Domain.Dialogue;

public static class CreatePhraseQueryApi
{
    public static async Task<IResult> Handler(
        [FromBody] PhraseGetResponseApiDto phraseGetResponseApiDto,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    ) {
        // Console.WriteLine(phraseGetResponseApiDto);
        // var updatedPhrase = await mediator.Send(new CreatePhraseRequest() {
        //     Phrase = DialogueMapping.MapDtoToModel(phrase)
        // });
        
        // if (updatedPhrase == null)
        // {
        //     return TypedResults.NoContent();
        // }

        return TypedResults.Ok();
    }
}
