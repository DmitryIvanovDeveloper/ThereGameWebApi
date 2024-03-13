using System.Linq;

namespace ThereGame.Api.Domain.Student.Queries;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThereGame.Api.Domain.Student;
using ThereGame.Business.Domain.Student.UseCases;
using ThereGame.Business.Domain.Word;

public static class UpdateStudentVocabularyQueryApi
{
    public static async Task<IResult> Handler(
        [FromBody] UpdateStudentVocabularyRequestApiDto updateStudentVocabularyRequest,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator
    )
    {
        await mediator.Send(new UpdateStudentVocabularyRequest()
        {
            TeacherId = updateStudentVocabularyRequest.TeacherId,
            StudentId = updateStudentVocabularyRequest.StudentId,
            Word = WordTranslateMapper.Map(updateStudentVocabularyRequest.WordData)
        });


        return TypedResults.Ok();
    }

    public static class WordTranslateMapper
    {
        public static WordModel Map(WordModelDto Word)
        {
            var translates = new List<WordTrasnalteModel>();

            foreach (var translateDto in Word.TranslatesData)
            {
                var translatetes = new WordTrasnalteModel()
                {
                    Id = translateDto.Id,
                    WordId = translateDto.WordId,
                    Language = translateDto.Language,
                    Translates = translateDto.Translates,
                };
                translates.Add(translatetes);
            }
            
            var word = new WordModel()
            {
               Id = Word.Id,
               Word = Word.Word,
               Translates = translates
            };

            return word;

        }
    }
}
