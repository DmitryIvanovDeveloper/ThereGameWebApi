using System.Linq;

namespace ThereGame.Api.Domain.Student.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Business.Domain.QuizlGameStatistic.UseCases;

public static class CreateTranslateWordsGameStatisticQueriesApi
{
    public static async Task<IResult> Handler(
        [FromBody] TranslateWordsGameStatisticDto statistic,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    )
    {
        await mediator.Send(new CreateTranslateWordsGameStatisticRequest()
        {
            TranslateWordsGameStatistic = TranslateWordsGameStatisticMapper.Map(statistic)
        });


        return TypedResults.Ok();
    }

    public static class TranslateWordsGameStatisticMapper
    {
        public static TranslateWordsGameStatisticModel Map(TranslateWordsGameStatisticDto dto)
        {
            var quizlGameStatistic = new TranslateWordsGameStatisticModel()
            {
                VocabularyBlockId = dto.VocabularyBlockId,
                WordId = dto.WordId,
                Answers = dto.Answers
            };

            return quizlGameStatistic;
        }
    }
}
