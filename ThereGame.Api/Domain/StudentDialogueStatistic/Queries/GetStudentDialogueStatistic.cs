namespace ThereGame.Api.Domain.StudentDialogueStatistic.Queries;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Business.Domain.StudentDialogueStatistic.UseCases;

public static class GetStudentDialogueStatisticApi
{
    public static async Task<IResult> Handler(
        [FromQuery] Guid id,
        [FromServices] IMediator mediator
    ) {
        var studentDialoguesStatistics = await mediator.Send(new GetStudentDialogueStatisticByIdRequest() {
            Id = id
        });
        
        if (studentDialoguesStatistics == null)
        {
            return TypedResults.NoContent();
        }

        var studentDialoguesStatistic = StudentDialogueStatisticMapping.Response(studentDialoguesStatistics);
        return TypedResults.Ok(studentDialoguesStatistic);
    }
}
