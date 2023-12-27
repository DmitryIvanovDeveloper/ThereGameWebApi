namespace ThereGame.Api.Domain.Answer.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Api.Util.Mappings;
using ThereGame.Business.Domain.User.UseCases;

public static class CreateStudentQueryApi
{
    public static async Task<IResult> Handler(
        [FromBody] AuthSignUpQueryApiDto authSignUpQueryApiDto,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    )
    {
        var token = await mediator.Send(new CreateStudentRequest()
        {
            Auth = UserMapping.Request(authSignUpQueryApiDto)
        });
        
        if (token == null)
        {
            return TypedResults.Conflict();
        }

        return TypedResults.Ok(token);
    }
}
