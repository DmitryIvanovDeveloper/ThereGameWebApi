namespace ThereGame.Api.Domain.Answer.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Business.Domain.Teacher.UseCases;

public static class UpdateTeacherByIdQueriesApi
{
    public static async Task<IResult> Handler(
        [FromHeader(Name = "X-THEREGAME-AUTH")] Guid id,
        [FromBody] TeacherRequestApiDto teacherUpdateRequestApiDto,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    ) {
        await mediator.Send(new UpdateTeacherByIdRequest() {
            Id = id,
            Avatar = teacherUpdateRequestApiDto.Avatar,
            Name = teacherUpdateRequestApiDto.Name,
            LastName = teacherUpdateRequestApiDto.LastName,
        });
        
        return TypedResults.Ok();
    }
}
