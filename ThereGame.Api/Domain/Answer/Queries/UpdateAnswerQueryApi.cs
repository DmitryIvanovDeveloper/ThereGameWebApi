namespace ThereGame.Api.Domain.Answer.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Api.Util.Mappings;
using ThereGame.Business.Domain.Dialogue.UseCases;

public static class UpdateAnswerQueryApi
{
    public static async Task<IResult> Handler(
        [FromBody] AnswerUpdateRequestApiDto answerUpdateRequestApiDto,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    ) {
        await mediator.Send(new UpdateAnswerRequest() {
            Answer = DialogueMapping.Request(answerUpdateRequestApiDto)
        });

        return TypedResults.Ok();
    }
}
