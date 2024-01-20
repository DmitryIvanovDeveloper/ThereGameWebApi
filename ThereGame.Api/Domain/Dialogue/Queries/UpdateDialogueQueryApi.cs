namespace ThereGame.Api.Domain.Answer.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Api.Domain.Dialogue;
using ThereGame.Business.Domain.Dialogue.UseCases;

public static class UpdateDialogueQueryApi
{
    public static async Task<IResult> Handler(
        [FromBody] DialogueUpdateRequestApiDto dialogueUpdateRequestApiDto,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    ) {
        await mediator.Send(new UpdateDialogueRequest() {
            VoiceSettings = dialogueUpdateRequestApiDto.VoiceSettings,
            Id = dialogueUpdateRequestApiDto.Id,
            Name = dialogueUpdateRequestApiDto.Name,
            LevelId = dialogueUpdateRequestApiDto.LevelId,
            TeacherId = dialogueUpdateRequestApiDto.TeacherId,
            IsPublished = dialogueUpdateRequestApiDto.IsPublished,
            PhraseId = dialogueUpdateRequestApiDto.PhraseId,
            StudentsId = dialogueUpdateRequestApiDto.StudentsId,
        });
        
        return TypedResults.Ok();
    }
}
