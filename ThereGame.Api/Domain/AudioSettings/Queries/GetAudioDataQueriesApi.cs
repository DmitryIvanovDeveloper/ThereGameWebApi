namespace ThereGame.Api.Domain.Answer.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Business.Domain.AudioSettings.UseCases;

public static class GetAudioDataQueriesApi
{
    public static async Task<IResult> Handler(
        [FromQuery] Guid id,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    )
    {
        var result = await mediator.Send(new GetAudioSettingsRequest() {
            Id = id
        });

        if (result == null)
        {
            return TypedResults.NoContent();
        }

        return TypedResults.Bytes(result);
    }
}
