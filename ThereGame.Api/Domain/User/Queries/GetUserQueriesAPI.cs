namespace ThereGame.Api.Domain.Answer.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Business.Domain.User.UseCases;

public static class GetUserQueryApi
{
    public static async Task<IResult> Handler(
        [FromBody] UserGetRequestApiDto userGetRequestApiDto,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    ) {
        
        var user = await mediator.Send(new GetUserRequest()
        {
            User = UserMapping.Request(userGetRequestApiDto)
        });
        
        if (user == null) {
            return TypedResults.Unauthorized();
        }

        var response = UserMapping.Response(user);
        
        return TypedResults.Ok(response);
    }
}
