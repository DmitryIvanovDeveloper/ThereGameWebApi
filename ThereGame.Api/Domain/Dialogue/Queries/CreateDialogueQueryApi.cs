namespace ThereGame.Api.Domain.Answer.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Api.Domain.Dialogue;
using ThereGame.Business.Domain.Dialogue.UseCases;

public static class CreateDialogueQueryApi
{
    public static async Task<IResult> Handler(
        [FromBody] DialogueCreateRequestApiDto dialogueCreateRequestApiDto,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    )
    {
        var updatedDialogue = await mediator.Send(new CreateDialogueRequest() {
            Id = dialogueCreateRequestApiDto.Id,
            Name = dialogueCreateRequestApiDto.Name,
            PhraseId = dialogueCreateRequestApiDto.PhraseId
        });
        
        if (updatedDialogue == null)
        {
            return TypedResults.NoContent();
        }

        return TypedResults.Ok(updatedDialogue);
    }
}
