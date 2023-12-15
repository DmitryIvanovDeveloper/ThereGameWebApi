namespace ThereGame.Api.Domain.Answer.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Api.Util.Mappings;
using ThereGame.Business.Domain.Dialogue.UseCases;

public static class CreateAnswerQueryApi
{
    public static async Task<IResult> Handler(
        [FromBody] AnswerCreateRequestApiDto answerCreateRequestApiDto,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    ) {
        await mediator.Send(new CreateAnswerRequest() {
            Answer = DialogueMapping.Request(answerCreateRequestApiDto)
        });
        
        return TypedResults.Ok();
    }
}
