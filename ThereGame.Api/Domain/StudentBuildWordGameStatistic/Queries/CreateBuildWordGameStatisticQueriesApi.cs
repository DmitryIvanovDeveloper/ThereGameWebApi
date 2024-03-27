using System.Linq;

namespace ThereGame.Api.Domain.Student.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Business.Domain.QuizlGameStatistic.UseCases;

public static class CreateBuildWordGameStatisticQueriesApi
{
    public static async Task<IResult> Handler(
        [FromBody] BuildWordGameStatisticDto statistic,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    )
    {
        await mediator.Send(new CreateBuildWordsGameStatisticRequest()
        {
             BuildWordsGameStatistic = BuildWordGameStatisticMapper.Map(statistic)
        });


        return TypedResults.Ok();
    }

    public static class BuildWordGameStatisticMapper
    {
        public static BuildWordsGameStatisticModel Map(BuildWordGameStatisticDto dto)
        {
            var buildWordsGamesStatistic = new BuildWordsGameStatisticModel()
            {
                VocabularyBlockId = dto.VocabularyBlockId,
                WordId = dto.WordId,
                Answers = dto.Answers
            };

            return buildWordsGamesStatistic;

        }
    }
}
