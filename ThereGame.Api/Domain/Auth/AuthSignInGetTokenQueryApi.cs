namespace ThereGame.Api.Domain.Answer.Queries;

using AutoMapper;
using Inspirer.Business.Domain.Common;
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
        var mediatrResponse = await mediator.Send(new AuthSignInGetTokenRequest()
        {
            Auth = AuthMapping.Request(authSignInQueryApiDto)
        });
        
        if (mediatrResponse.Status == MediatorResponseStatuses.PROFILE__NOT_FOUND ||
            mediatrResponse.Status == MediatorResponseStatuses.SIGN_IN__INVALID_PASSWORD
        ) 
        {
            return TypedResults.Unauthorized();
        }
       
        var auth = new Auth 
        {
            Token = mediatrResponse.Data?.Data.Token
        };
        return TypedResults.Ok(auth);
    }

    public class Auth {
        public Guid? Token  { get; set; }
    }
}
