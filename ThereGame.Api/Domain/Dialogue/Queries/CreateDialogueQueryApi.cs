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
    ) {
        await mediator.Send(new CreateDialogueRequest() {
            Id = dialogueCreateRequestApiDto.Id,
            LevelId = dialogueCreateRequestApiDto.LevelId,
            IsPublished = dialogueCreateRequestApiDto.IsPublished,
            Name = dialogueCreateRequestApiDto.Name,
            Phrase = DialogueMapping.Request(dialogueCreateRequestApiDto.Phrase)
        });

        return TypedResults.Ok();
    }
}
