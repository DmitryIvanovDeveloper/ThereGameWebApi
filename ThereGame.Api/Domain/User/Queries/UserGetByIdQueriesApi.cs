namespace ThereGame.Api.Domain.Answer.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Api.Util.Mappings;
using ThereGame.Business.Domain.User.UseCases;

public static class UserGetByIdQueriesApi
{
    public static async Task<IResult> Handler(
        [FromHeader(Name = "X-THEREGAME-AUTH")] Guid id,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    ) {
        var user = await mediator.Send(new GetUserByIdRequest() {
            Id = id
        });
        
        if (user == null)
        {
            return TypedResults.NoContent();
        }
    
        var response = UserMapping.Response(user);

        return TypedResults.Ok(response);
    }
}
