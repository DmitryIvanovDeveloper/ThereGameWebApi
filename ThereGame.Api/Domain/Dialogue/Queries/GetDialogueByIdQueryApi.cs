namespace ThereGame.Api.Domain.Answer.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Business.Domain.Answer;
using ThereGame.Business.Domain.Dialogue;
using ThereGame.Business.Domain.Dialogue.UseCases;
using ThereGame.Business.Domain.Phrase;

public static class GetDialogueByIdQueryApi
{
    public static async Task<IResult> Handler(
        [FromRoute] Guid id,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    )
    {
        var answer = new AnswerModel()
        {
            Id = new Guid("4f6b2cc4-e279-456a-9b8d-c44c30cc9cf7"),
            Text = "Hello, Huibolo",

        };

        var phrase = new PhraseModel()
        {
            Id = new Guid("f2ec969e-c4b3-40d3-9667-b6098a135e36"),
            Text = "Hello, Pidr",
        };

        phrase.Answers.Add(answer);

        var dialogue = await mediator.Send(new GetDialogueByIdRequest { Id = id });
        var newDialogue = new DialogueModel()
        {
            Id = new Guid("65079c83-07b7-512a-90fe-8ce5c7a239e7"),
            Phrase = phrase,
            Name = "Hui Morjoviy"
        };
        if (newDialogue == null)
        {
            return TypedResults.NoContent();
        }

        return TypedResults.Ok(newDialogue);
    }
}
