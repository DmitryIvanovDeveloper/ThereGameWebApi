namespace ThereGame.Api.Domain.Answer.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Api.Util.Mappings;
using ThereGame.Business.Domain.Dialogue.UseCases;

public static class GetDialoguesQueryApi
{
    public static async Task<IResult> Handler(
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    )
    {
        var dialogues = await mediator.Send(new GetDialoguesRequest());
        if (dialogues == null)
        {
            return TypedResults.NoContent();
        }

        var response = DialogueMapping.Response(dialogues);

        foreach (var dialogue in response)
        {
            foreach (var answer in dialogue.Phrase.Answers)
            {
                Console.WriteLine($"++++++++{answer.Id} = {answer.Phrases.Count()}++++++++");
            }
        }
        
        return TypedResults.Ok(response);
    }
}
