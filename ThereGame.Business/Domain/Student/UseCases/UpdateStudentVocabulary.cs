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
        //TODO: Refactoring
        var student = await _dataService.Students.FindAsync(request.StudentId);

        if (student == null ||
            student.TeacherId != request.TeacherId ||
            request.Word.Word == "")
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
            student.VocabularyIdList.Add(request.Word.Id);
            AddNewWord(request.Word);
            AddTranslates(request.Word.Translates);
        }
        else
        {
           await UpdateTranslates(request.Word.Translates);
        }
        if (!student.VocabularyIdList.Contains(request.Word.Id))
        {
            student.VocabularyIdList.Add(request.Word.Id);
        }
        await _dataService.SaveChanges(cancellationToken);
    }
    private void AddNewWord(WordModel data)
    {
        data.Word = RemoveExtraSymbols(data.Word);
        _dataService.Words.Add(data);
    }

    private void AddTranslates(List<WordTrasnalteModel> translates) 
    {
        foreach (var currentTranslate in translates)
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
    private async Task UpdateTranslates(List<WordTrasnalteModel> wordTranslatesData) 
    {
        foreach (var currentTranslateData in wordTranslatesData)
        {
            var expectedTranslate = await _dataService.WordTranslates.FindAsync(currentTranslateData.Id);
            if (expectedTranslate == null)
            {
               AddTranslates(wordTranslatesData);
               continue;
            }

            expectedTranslate.Translates = RemoveEmptyTranslate(currentTranslateData.Translates);
        }
    }

    private List<string> RemoveEmptyTranslate(List<string> translates)
    {
        return translates.Where(t => !string.IsNullOrEmpty(t)).ToList();
    }

    private string RemoveExtraSymbols(string text)
    {
        return string.Concat(text.ToLower().Where(char.IsLetter)).Trim();
    }
}