namespace ThereGame.Api.Domain.Answer.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Business.Domain.Student.UseCases;

public static class GetStudentByIdQueriesApi
{
    public static async Task<IResult> Handler(
        [FromHeader(Name = "X-THEREGAME-AUTH")] Guid id,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    ) {
        
        var student = await mediator.Send(new GetStudentByIdRequest() {
            Id = id
        });
        
        if (student == null)
        {
            return TypedResults.Unauthorized();
        }
    
        var response = StudentMapping.Response(student);

        return TypedResults.Ok(response);
    }
}
