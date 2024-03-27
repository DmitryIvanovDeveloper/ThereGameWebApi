using System.Linq;

namespace ThereGame.Api.Domain.Student.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Business.Domain.QuizlGameStatistic.UseCases;

public static class CreateQuizlGameStatisticQueriesApi
{
    public static async Task<IResult> Handler(
        [FromBody] QuizlGameStatisticDto statistic,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    )
    {
        await mediator.Send(new CreateQuizlGameStatisticRequest()
        {
            QuizlGameStatistic = QuizlGameStatisticMapper.Map(statistic)
        });


        return TypedResults.Ok();
    }

    public static class QuizlGameStatisticMapper
    {
        public static QuizlGameStatisticModel Map(QuizlGameStatisticDto dto)
        {
            var quizlGameStatistic = new QuizlGameStatisticModel()
            {
                VocabularyBlockId = dto.VocabularyBlockId,
                QuizlGameId = dto.QuizlGameId,
                Answers = dto.Answers
            };

            return quizlGameStatistic;

        }
    }
}
