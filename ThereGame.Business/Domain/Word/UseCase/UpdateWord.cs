namespace ThereGame.Business.Domain.Student.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;
using ThereGame.Business.Domain.Word;

public class UpdateWordRequest : IRequest
{
    required public WordModel Word { get; set; }
}

public class UpdateWord(IThereGameDataService dataService) : IRequestHandler<UpdateWordRequest>
{
    private readonly IThereGameDataService _dataService = dataService;

    public async Task Handle(UpdateWordRequest request, CancellationToken cancellationToken)
    {
        if (request.Word.Word == "")
        {
            return;
        }

        var expectedWord = await _dataService.Words.FindAsync(request.Word.Id);
        if (expectedWord == null)
        {
            return; // TODO: Return an error about unexisting word
        }
        expectedWord.Word = request.Word.Word;
        expectedWord.SpeechParts = request.Word.SpeechParts;
        expectedWord.Pictures = request.Word.Pictures;
        expectedWord.Forms = request.Word.Forms;
        
        await UpdateTranslates(request.Word.Translates);
      
        await _dataService.SaveChanges(cancellationToken);
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