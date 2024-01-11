namespace ThereGame.Api.Domain.Answer.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Api.Util.Mappings;
using ThereGame.Business.Domain.Teacher.UseCases;

public static class AuthSignInGetTokenQueryApi
{
    public static async Task<IResult> Handler(
        [FromBody] AuthSignInQueryApiDto authSignInQueryApiDto,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    ) {
        var token = await mediator.Send(new AuthSignInGetTokenRequest()
        {
            Auth = AuthMapping.Request(authSignInQueryApiDto)
        });
        
        if (token == null) {
            return TypedResults.Unauthorized();
        }

        var response = new AuthSignInResponseQueryApi()
        {
            Token = token
        };

        return TypedResults.Ok(response);
    }

    public class AuthSignInResponseQueryApi
    {
        public Guid? Token { get; set; }
    }
}
