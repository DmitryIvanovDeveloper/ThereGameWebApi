namespace ThereGame.Api.Domain.Answer.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Api.Domain.Dialogue;
using ThereGame.Business.Domain.Dialogue.UseCases;

public static class DeleteDialogueQueryApi
{
    public static async Task<IResult> Handler(
        [FromBody] DialogueDeleteRequestApiDto dialogueDeleteRequestApiDto,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    ) {
        await mediator.Send(new DeleteDialogueRequest() {
            Id = dialogueDeleteRequestApiDto.Id
        });

        return TypedResults.Ok();
    }
}
