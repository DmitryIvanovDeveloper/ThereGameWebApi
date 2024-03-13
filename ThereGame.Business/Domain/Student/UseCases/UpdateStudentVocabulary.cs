namespace ThereGame.Business.Domain.Student.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;
using ThereGame.Business.Domain.Word;

public class UpdateStudentVocabularyRequest : IRequest
{
    required public Guid TeacherId { get; set; }
    required public Guid StudentId { get; set; }
    required public WordModel Word { get; set; }
}

public class UpdateStudentVocabulary(IThereGameDataService dataService) : IRequestHandler<UpdateStudentVocabularyRequest>
{
    private readonly IThereGameDataService _dataService = dataService;

    public async Task Handle(UpdateStudentVocabularyRequest request, CancellationToken cancellationToken)
    {
        var student = await _dataService.Students.FindAsync(request.StudentId);

        if (student == null || student.TeacherId != request.TeacherId)
        {
            return;
        }

        if (student.VocabularyIdList == null)
        {
            student.VocabularyIdList = new List<Guid>();
            await _dataService.SaveChanges(cancellationToken);
        }

        var expectedWord = await _dataService.Words.FindAsync(request.Word.Id);
        if (expectedWord == null)
        {
            request.Word.Word = RemoveExtraSymbols(request.Word.Word);
            _dataService.Words.Add(request.Word);

            foreach (var currentTranslate in request.Word.Translates)
            {
                var updatedTranslate = new List<string>();
                foreach (var translate in currentTranslate.Translates)
                {
                    updatedTranslate.Add(RemoveExtraSymbols(translate));
                }
                currentTranslate.Translates = updatedTranslate;
                _dataService.WordTranslates.Add(currentTranslate);
            }
        }
        else
        {
            foreach (var currentTranslate in request.Word.Translates)
            {
                var expectedTrasnlate = await _dataService.WordTranslates.FindAsync(currentTranslate.Id);
                if (expectedTrasnlate == null)
                {
                    var updatedTranslate = new List<string>();

                    foreach (var translate in currentTranslate.Translates)
                    {
                        updatedTranslate.Add(RemoveExtraSymbols(translate));
                    }
                    currentTranslate.Translates = updatedTranslate;
                    _dataService.WordTranslates.Add(currentTranslate);
                }
                else
                {
                    var difference = expectedTrasnlate.Translates.Except(currentTranslate.Translates).FirstOrDefault();
                    if (difference != null)
                    {
                          expectedTrasnlate.Translates.Add(difference);
                    }
                }
            }

        }
        if (!student.VocabularyIdList.Contains(request.Word.Id))
        {
            student.VocabularyIdList.Add(request.Word.Id);
        }
        await _dataService.SaveChanges(cancellationToken);
    }

    private string RemoveExtraSymbols(string text)
    {
        return string.Concat(text.ToLower().Where(char.IsLetter)).Trim();
    }
}