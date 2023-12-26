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
        var user = await mediator.Send(new GetUserRequest()
        {
            User = UserMapping.Request(authSignInQueryApiDto)
        });
        
        if (user == null) {
            return TypedResults.Unauthorized();
        }

        var response = UserMapping.Response(user);
        
        return TypedResults.Ok(response);
    }
}
