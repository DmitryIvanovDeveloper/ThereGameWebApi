namespace ThereGame.Api.Domain.Answer.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Business.Domain.User.UseCases;

public static class CreateUserQueryApi
{
    public static async Task<IResult> Handler(
        [FromBody] UserCreateRequestApiDto userCreateRequestApiDto,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    ) {
        
        await mediator.Send(new CreateUserRequest()
        {
            User = UserMapping.Request(userCreateRequestApiDto)
        });
        
        return TypedResults.Ok();
    }
}
