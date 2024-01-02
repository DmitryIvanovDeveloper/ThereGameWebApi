namespace ThereGame.Api.Domain.Answer.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Api.Util.Mappings;
using ThereGame.Business.Domain.Teacher.UseCases;

public static class AuthSignUpStudentQueryApi
{
    public static async Task<IResult> Handler(
        [FromBody] AuthSignUpQueryApiDto authSignUpQueryApiDto,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    ) {
        var token = await mediator.Send(new CreateStudentRequest
        {
            Auth = AuthMapping.Request(authSignUpQueryApiDto)
        });

        if (token == null)
        {
            return TypedResults.Conflict();
        }
        
        return TypedResults.Ok(token);
    }
}
