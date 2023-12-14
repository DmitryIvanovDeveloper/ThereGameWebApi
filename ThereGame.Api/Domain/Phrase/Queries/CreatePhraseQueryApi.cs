namespace ThereGame.Api.Domain.Answer.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Api.Domain.Dialogue;
using ThereGame.Api.Util.Mappings;
using ThereGame.Business.Domain.Dialogue.UseCases;

public static class CreateAnswerQueryApi
{
    public static async Task<IResult> Handler(
        [FromBody] AnswerGetResponseApiDto answer,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    )
    {
        var updatedAnswer = await mediator.Send(new CreateAnswerRequest() {
            Answer = DialogueMapping.MapDtoToModel(answer)
        });
        
        if (updatedAnswer == null)
        {
            return TypedResults.NoContent();
        }

        return TypedResults.Ok(updatedAnswer);
    }
}
