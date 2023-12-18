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
            Id = dialogueUpdateRequestApiDto.Id,
            Name = dialogueUpdateRequestApiDto.Name,
            LevelId = dialogueUpdateRequestApiDto.LevelId,
            IsPublished = dialogueUpdateRequestApiDto.IsPublished,
            PhraseId = dialogueUpdateRequestApiDto.PhraseId
        });
        
        return TypedResults.Ok();
    }
}
