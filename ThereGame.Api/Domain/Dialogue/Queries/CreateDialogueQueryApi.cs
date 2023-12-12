namespace ThereGame.Api.Domain.Answer.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Business.Domain.Dialogue.UseCases;

public static class CreateDialogueQueryApi
{
    public static async Task<IResult> Handler(
        [FromBody] DialogueDto body,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    )
    {
        Console.WriteLine(body);
        
        var dialogue = await mediator.Send(new CreateDialogueRequest());
        if (dialogue == null)
        {
            return TypedResults.NoContent();
        }

        return TypedResults.Ok();
    }
}
