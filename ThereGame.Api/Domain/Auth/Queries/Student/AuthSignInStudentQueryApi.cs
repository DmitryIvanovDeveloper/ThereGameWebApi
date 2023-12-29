namespace ThereGame.Api.Domain.Answer.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Api.Util.Mappings;
using ThereGame.Business.Domain.User.UseCases;

public static class AuthSignInStudentQueryApi
{
    public static async Task<IResult> Handler(
        [FromBody] AuthSignInQueryApiDto authSignInQueryApiDto,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    ) {
        var token = await mediator.Send(new AuthSignInStudentRequest()
        {
            Student = AuthMapping.Request(authSignInQueryApiDto)
        });
        
        if (token == null) {
            return TypedResults.Unauthorized();
        }

        return TypedResults.Ok(token);
    }
}
