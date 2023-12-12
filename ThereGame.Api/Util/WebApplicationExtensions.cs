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
        dialoguesGroup.MapPost("", CreateDialogueQueryApi.Handler);

        return app;
    }
}