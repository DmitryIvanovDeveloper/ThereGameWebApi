namespace ThereGame.Api.Domain.Answer.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Api.Domain.Dialogue;
using ThereGame.Api.Util.Mappings;
using ThereGame.Business.Domain.Dialogue.UseCases;

public static class CreateDialogueQueryApi
{
    public static async Task<IResult> Handler(
        [FromBody] DialogueCreateRequestApiDto dialogueCreateRequestApiDto,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    )
    {
        Console.WriteLine(DialogueMapping.MapDtoToModel(dialogueCreateRequestApiDto));
        
        var dialogue = await mediator.Send(new CreateDialogueRequest() {
            Id = dialogueCreateRequestApiDto.Id,
            Name = dialogueCreateRequestApiDto.Name,
            PhraseId = dialogueCreateRequestApiDto.PhraseId
        });
        
        if (dialogue == null)
        {
            return TypedResults.NoContent();
        }

        return TypedResults.Ok(dialogue);
    }
}
