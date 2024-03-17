using System.Linq;

namespace ThereGame.Api.Domain.Student.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Api.Domain.Student;
using ThereGame.Business.Domain.Student;
using ThereGame.Business.Domain.StudentDialogueStatistic.UseCases;

public static class CreateStudentVocabularyBlockQueryApi
{
    public static async Task<IResult> Handler(
        [FromBody] CreateStudentVocabularyBlockDto updateStudentVocabularyRequest,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    )
    {
        await mediator.Send(new CreateStudenVocabularyBlockRequest()
        {
            StudentVocabularyBlock = StudentVocabularyBlockMapper.Map(updateStudentVocabularyRequest)
        });

        return TypedResults.Ok();
    }

    public static class StudentVocabularyBlockMapper
    {
        public static StudentVocabularyBlockModel Map(CreateStudentVocabularyBlockDto studentVocabularyBlockModelDto)
        {
            var studentVocabularyBlockModel = new StudentVocabularyBlockModel() {
                Id = studentVocabularyBlockModelDto.Id,
                StudentId = studentVocabularyBlockModelDto.StudentId,
                Name = studentVocabularyBlockModelDto.Name,
                CreatedAt = DateTime.UtcNow
            };

            return studentVocabularyBlockModel;
        }
    }
}
