namespace ThereGame.Api.Domain.Answer.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Api.Domain.Dialogue;
using ThereGame.Api.Util.Mappings;
using ThereGame.Business.Domain.Dialogue.UseCases;

public static class UpdateDialogueQueryApi
{
    public static async Task<IResult> Handler(
        [FromBody] DialogueGetResponseApiDto dialogue,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    )
    {
        var dialogue1 = await mediator.Send(new UpdateDialogueRequest() {
            Dialogue = DialogueMapping.MapDtoToModel(dialogue)
        });
        
        if (dialogue == null)
        {
            return TypedResults.NoContent();
        }

        return TypedResults.Ok(dialogue1);
    }
}
