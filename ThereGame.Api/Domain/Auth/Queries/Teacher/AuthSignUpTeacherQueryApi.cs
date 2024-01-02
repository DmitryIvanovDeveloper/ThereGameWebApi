namespace ThereGame.Api.Domain.Answer.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Api.Util.Mappings;
using ThereGame.Business.Domain.Teacher.UseCases;

public static class AuthSignUpTeacherQueryApi
{
    public static async Task<IResult> Handler(
        [FromBody] AuthSignUpQueryApiDto authSignUpQueryApiDto,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    ) {
        
        if (authSignUpQueryApiDto.Email == "" || 
            authSignUpQueryApiDto.Name == "" || 
            authSignUpQueryApiDto.LastName == "" ||
            authSignUpQueryApiDto.Password == ""
        )
        {
            return TypedResults.BadRequest();
        }
        
        var token = await mediator.Send(new AuthSignUpTeacherRequest()
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
