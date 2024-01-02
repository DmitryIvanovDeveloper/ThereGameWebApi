namespace ThereGame.Api.Domain.Answer.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Api.Util.Mappings;
using ThereGame.Business.Domain.Teacher.UseCases;

public static class TeacherGetByIdQueriesApi
{
    public static async Task<IResult> Handler(
        [FromHeader(Name = "X-THEREGAME-AUTH")] Guid id,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    ) {
        var teacher = await mediator.Send(new GetTeacherByIdRequest() {
            Id = id
        });
        
        if (teacher == null)
        {
            return TypedResults.Unauthorized();
        }
    
        var response = TeacherMapping.Response(teacher);

        return TypedResults.Ok(response);
    }
}
