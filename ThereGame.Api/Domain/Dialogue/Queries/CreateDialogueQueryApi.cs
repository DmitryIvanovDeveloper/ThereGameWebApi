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
            IsVoiceSelected = dialogueCreateRequestApiDto.IsVoiceSelected,
            Id = dialogueCreateRequestApiDto.Id,
            LevelId = dialogueCreateRequestApiDto.LevelId,
            TeacherId = dialogueCreateRequestApiDto.TeacherId,
            IsPublished = dialogueCreateRequestApiDto.IsPublished,
            Name = dialogueCreateRequestApiDto.Name,
            StudentsId = dialogueCreateRequestApiDto.StudentsId,
            Phrase = DialogueMapping.Request(dialogueCreateRequestApiDto.Phrase)
        });

        return TypedResults.Ok();
    }
}
