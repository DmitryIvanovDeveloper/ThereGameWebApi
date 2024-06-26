using ThereGame.Api.Domain.Answer.Queries;
using ThereGame.Api.Domain.QuizlGame.Queries;
using ThereGame.Api.Domain.Student.Queries;
using ThereGame.Api.Domain.StudentDialogueStatistic.Queries;

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
        apiGroup.MapPost("auth/sign-in/me", AuthSignInGetWebTokenQueryApi.Handler);

        apiGroup.MapPost("auth/sign-up/teachers", AuthSignUpTeacherQueryApi.Handler);
        apiGroup.MapPost("auth/sign-up/students", AuthSignUpStudentQueryApi.Handler);

        var teachersGroup = apiGroup.MapGroup("/teachers");
        teachersGroup.MapGet("/me", GetTeacherByIdQueriesApi.Handler);
        teachersGroup.MapPost("/me", UpdateTeacherByIdQueriesApi.Handler);

        var studentGroup = apiGroup.MapGroup("/students");
        studentGroup.MapGet("/statistics/dialogues", GetStudentDialogueStatisticApi.Handler);
      
        studentGroup.MapGet("/me", GetStudentByIdQueriesApi.Handler);
        studentGroup.MapPost("/me/statistics/dialogues", CreateStudentDialogueStatisticApi.Handler);

        var vocabularyBlockGroup = apiGroup.MapGroup("/vocabularyBlocks");
        vocabularyBlockGroup.MapGet("/", GetStudentVocabularyByIdQueriesApi.Handler);
        vocabularyBlockGroup.MapPut("/", UpdateStudentVocabularyBlockQueryApi.Handler);
        vocabularyBlockGroup.MapPost("/", CreateStudentVocabularyBlockQueryApi.Handler);
        vocabularyBlockGroup.MapDelete("/", DeleteStudentVocabularyBlockQueryApi.Handler);

        var wordsGroup = apiGroup.MapGroup("/words");

        wordsGroup.MapPost("/", CreateWordQueriesApi.Handler);
        wordsGroup.MapPut("/", UpdateWordQueriesApi.Handler);
        wordsGroup.MapGet("/", GetWordsQueriesApi.Handler);
        wordsGroup.MapGet("/range", GetWordsByIdQueriesApi.Handler);

        var quizlGroup = apiGroup.MapGroup("/quizlGames");
        quizlGroup.MapGet("/", GetQuizlGameByIdsQueriesApi.Handler);
        quizlGroup.MapGet("/word", GetQuizlGamesByWordIdQueriesApi.Handler);
        quizlGroup.MapPost("/", CreateQuizlGameQueriesApi.Handler);
        quizlGroup.MapPut("/", UpdateQuizlGameQueriesApi.Handler);
        quizlGroup.MapDelete("/", DeleteQuizlGameQueriesApi.Handler);

        var quizlStatisticGroup = apiGroup.MapGroup("/quizlGameStatistics");
        quizlStatisticGroup.MapPost("/", CreateQuizlGameStatisticQueriesApi.Handler);

        var translateWordsGameStatisticGroup = apiGroup.MapGroup("/translateWordsGameStatistics");
        translateWordsGameStatisticGroup.MapPost("/", CreateTranslateWordsGameStatisticQueriesApi.Handler);

        var buildWordsGameStatisticGroup = apiGroup.MapGroup("/buildWordsGameStatistics");
        buildWordsGameStatisticGroup.MapPost("/", CreateBuildWordGameStatisticQueriesApi.Handler);

        var audioDataGroup = apiGroup.MapGroup("/audioData");
        audioDataGroup.MapGet("/", GetAudioDataQueriesApi.Handler);

        return app;
    }
}