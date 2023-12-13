using ThereGame.Api.Domain.Answer.Queries;

namespace Microsoft.AspNetCore.Builder;


public static class WebApplicationExtensions
{
    public static WebApplication UseThereGame(this WebApplication app)
    {
        var apiGroup = app.MapGroup("/api"); // TODO: Each query to /api/* should be authorized

        // Dialogue
        var dialoguesGroup = apiGroup.MapGroup("/dialogues");
        dialoguesGroup.MapGet("{id:guid}", GetDialogueByIdQueryApi.Handler);
        dialoguesGroup.MapPost("/", CreateDialogueQueryApi.Handler);
        dialoguesGroup.MapDelete("{id:guid}", DeleteDialogueQueryApi.Handler);
        dialoguesGroup.MapPut("/", UpdateDialogueQueryApi.Handler);

        // Phrase
        var phraseGroup = apiGroup.MapGroup("/pharses");
        phraseGroup.MapGet("{id:guid}", GetPhraseByIdQueryApi.Handler);
        phraseGroup.MapGet("/", CreatePhraseQueryApi.Handler);
        phraseGroup.MapDelete("{id:guid}", DeletePhraseQueryApi.Handler);
        phraseGroup.MapPut("d/", UpdatePhraseQueryApi.Handler);

         // Answer
        var answerGroup = apiGroup.MapGroup("/answers");
        answerGroup.MapGet("{id:guid}", GetAnswerByIdQueryApi.Handler);
        answerGroup.MapGet("/", CreateAnswerQueryApi.Handler);
        answerGroup.MapDelete("{id:guid}", DeleteAnswerQueryApi.Handler);
        answerGroup.MapPut("/", UpdateAnswerQueryApi.Handler);

        return app;
    }
}