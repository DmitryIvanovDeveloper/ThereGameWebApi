using ThereGame.Api.Domain.Answer.Queries;

namespace Microsoft.AspNetCore.Builder;

public static class WebApplicationExtensions
{
    public static WebApplication UseThereGame(this WebApplication app)
    {
        var apiGroup = app.MapGroup("/api"); // TODO: Each query to /api/* should be authorized

        // Dialogue
        var dialoguesGroup = apiGroup.MapGroup("/dialogues");
        dialoguesGroup.MapGet("/published", GetPublishedDialoguesQueryApi.Handler);
        dialoguesGroup.MapGet("/", GetDialoguesQueryApi.Handler);
        dialoguesGroup.MapPost("/", CreateDialogueQueryApi.Handler);
        dialoguesGroup.MapDelete("{id:guid}", DeleteDialogueQueryApi.Handler);
        dialoguesGroup.MapPut("/", UpdateDialogueQueryApi.Handler);

        // Phrase
        var phraseGroup = apiGroup.MapGroup("/phrases");
        phraseGroup.MapGet("{id:guid}", GetPhraseByIdQueryApi.Handler);
        phraseGroup.MapPost("/", CreatePhraseQueryApi.Handler);
        phraseGroup.MapDelete("{id:guid}", DeletePhraseQueryApi.Handler);
        phraseGroup.MapPut("/", UpdatePhraseQueryApi.Handler);

        // Answer
        var answerGroup = apiGroup.MapGroup("/answers");
        answerGroup.MapGet("{id:guid}", GetAnswerByIdQueryApi.Handler);
        answerGroup.MapPost("/", CreateAnswerQueryApi.Handler);
        answerGroup.MapDelete("{id:guid}", DeleteAnswerQueryApi.Handler);
        answerGroup.MapPut("/", UpdateAnswerQueryApi.Handler);

        // Auth
        apiGroup.MapPost("auth/sign-in", AuthSignInGetTokenQueryApi.Handler);
        apiGroup.MapPost("auth/sign-in/web", AuthSignInGetWebTokenQueryApi.Handler);

        apiGroup.MapPost("auth/sign-up/teachers", AuthSignUpTeacherQueryApi.Handler);
        apiGroup.MapPost("auth/sign-up/students", AuthSignUpStudentQueryApi.Handler);

        var teachersGroup = apiGroup.MapGroup("/teachers");
        teachersGroup.MapGet("/me", GetTeacherByIdQueriesApi.Handler);
        teachersGroup.MapPost("/me", UpdateTeacherByIdQueriesApi.Handler);

        var studentGroup = apiGroup.MapGroup("/students");
        studentGroup.MapGet("/me", GetStudentByIdQueriesApi.Handler);

        return app;
    }
}