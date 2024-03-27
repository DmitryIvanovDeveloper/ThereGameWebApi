using System.Linq;

namespace ThereGame.Api.Domain.Student.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Api.Domain.Student;
using ThereGame.Business.Domain.Student;
using ThereGame.Business.Domain.StudentDialogueStatistic.UseCases;

public static class UpdateStudentVocabularyBlockQueryApi
{
    public static async Task<IResult> Handler(
        [FromBody] UpdateStudentVocabularyBlockDto updateStudentVocabularyRequest,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    )
    {
        await mediator.Send(new UpdateStudenVocabularyBlockRequest()
        {
            StudentVocabularyBlock = StudentVocabularyBlockMapper.Map(updateStudentVocabularyRequest)
        });


        return TypedResults.Ok();
    }

    public static class StudentVocabularyBlockMapper
    {
         public static StudentVocabularyBlockModel Map(UpdateStudentVocabularyBlockDto studentVocabularyBlockModelDto)
        {
            var studentVocabularyBlockModel = new StudentVocabularyBlockModel() {
                Id = studentVocabularyBlockModelDto.Id,
                StudentId = studentVocabularyBlockModelDto.StudentId,
                Name = studentVocabularyBlockModelDto.Name,
                WordsId = studentVocabularyBlockModelDto.WordsId,
                CreatedAt = studentVocabularyBlockModelDto.CreatedAt
            };

            return studentVocabularyBlockModel;
        }
    }
}
