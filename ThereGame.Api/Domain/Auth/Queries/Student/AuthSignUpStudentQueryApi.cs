namespace ThereGame.Api.Domain.Answer.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Api.Util.Mappings;
using ThereGame.Business.Domain.User.UseCases;

public static class AuthSignUpStudentQueryApi
{
    public static async Task<IResult> Handler(
        [FromBody] AuthSignUpQueryApiDto authSignUpQueryApiDto,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    ) {
        await mediator.Send(new CreateStudentRequest
        {
            Auth = UserMapping.Request(authSignUpQueryApiDto)
        });
        
        return TypedResults.Ok();
    }
}
