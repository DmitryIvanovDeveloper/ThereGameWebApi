using System.Linq;

namespace ThereGame.Api.Domain.Student.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Business.Domain.StudentDialogueStatistic.UseCases;

public static class DeleteStudentVocabularyBlockQueryApi
{
    public static async Task<IResult> Handler(
        [FromQuery] Guid Id,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    )
    {
        await mediator.Send(new DeleteStudenVocabularyBlockRequest()
        {
            Id = Id
        });


        return TypedResults.Ok();
    }
}
