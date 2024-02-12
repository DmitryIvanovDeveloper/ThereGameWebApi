namespace ThereGame.Api.Domain.StudentDialogueStatistic.Queries;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Business.Domain.StudentDialogueStatistic.UseCases;

public static class CreateStudentDialogueStatisticApi
{
    public static async Task<IResult> Handler(
        [FromBody] StudentDialogueStatisticDto studentDialogueStatisticDto,
        [FromServices] IMediator mediator
    ) {
        await mediator.Send(new CreateStudentDialogueStatisticRequest() {
            StudentDialogueStatistic = StudentDialogueStatisticMapping.Request(studentDialogueStatisticDto)
        });

        return TypedResults.Ok();
    }
}
