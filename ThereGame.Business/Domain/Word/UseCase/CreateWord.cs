namespace ThereGame.Business.Domain.Student.UseCases;

using ThereGame.Business.Util.Services;
using MediatR;
using ThereGame.Business.Domain.Word;

public class CreateWordRequest : IRequest
{
    required public WordModel Word { get; set; }
}

public class CreateWord(IThereGameDataService dataService) : IRequestHandler<CreateWordRequest>
{
    private readonly IThereGameDataService _dataService = dataService;

    public async Task Handle(CreateWordRequest request, CancellationToken cancellationToken)
    {
        var expectedWord = await _dataService.Words.FindAsync(request.Word.Id);

        if (request.Word.Word == "" )
        {
            return;
        }

        if (expectedWord != null)
        {
            return; // TODO: Return an error about existing word
        }

        AddNewWord(request.Word);
        AddTranslates(request.Word.Translates);

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

    private string RemoveExtraSymbols(string text)
    {
        return string.Concat(text.ToLower().Where(char.IsLetter));
    }
}