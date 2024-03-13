namespace ThereGame.Api.Domain.Answer.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Business.Domain.Student.UseCases;

public static class GetStudentVocabularyByIdQueriesApi
{
    public static async Task<IResult> Handler(
        [FromHeader(Name = "X-THEREGAME-AUTH")] Guid id,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    ) {
        
        var vicabularies = await mediator.Send(new GetStudentVocabularyByIdRequest() {
            Id = id
        });
        
        if (vicabularies.Count == 0)
        {
            return TypedResults.NoContent();
        }
    

        return TypedResults.Ok(vicabularies);
    }
}
