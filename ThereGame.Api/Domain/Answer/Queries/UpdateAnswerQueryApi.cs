namespace ThereGame.Api.Domain.Answer.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Api.Domain.Dialogue;
using ThereGame.Api.Util.Mappings;
using ThereGame.Business.Domain.Dialogue.UseCases;

public static class UpdateAnswerQueryApi
{
    public static async Task<IResult> Handler(
        [FromBody] AnswerGetResponseApiDto answer,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    )
    {
        var updatedAnswer = await mediator.Send(new UpdateAnswerRequest() {
            Answer = DialogueMapping.MapDtoToModel(answer)
        });
        if (updatedAnswer == null)
        {
            return TypedResults.NoContent();
        }

        return TypedResults.Ok(updatedAnswer);
    }
}
