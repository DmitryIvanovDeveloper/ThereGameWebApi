using System.Diagnostics;
using ThereGame.Business.Domain.Answer;
using ThereGame.Business.Domain.Dialogue;
using ThereGame.Business.Domain.Phrase;
using ThereGame.Business.Util.Services;

public class RemoveDialogueItems(IThereGameDataService dataService) : IRemoveDialogueItems
{
    private readonly IThereGameDataService _dataService = dataService;

    public async void Remove(DialogueModel dialogue, CancellationToken cancellationToken)
    {
        Console.WriteLine($"===============Dialogie {dialogue.Id}===========");

        var fullDialogie = await _dataService.GetFullDialogues(cancellationToken);
        // Console.WriteLine($"===============fullDialogie {fullDialogie.Id}===========");
    
        // if (fullDialogie == null)
        // {
        //     return;
        // }

       
        // Remove(dialogue.Phrase, cancellationToken);

        // _dataService.Dialogues.RemoveRange(dialogue);
    }
    public async void Remove(PhraseModel phrase, CancellationToken cancellationToken)
    {
        Console.WriteLine($"======= Phrase{phrase.Id}=======");

        var fullPhrase = await _dataService.GetFullPhraseById(phrase.Id, cancellationToken);
        Console.WriteLine($"======= fullPhrase{fullPhrase.Id}=======");

        if (fullPhrase == null)
        {
            return;
        }

        foreach (var answer in fullPhrase.Answers)
        {
            Remove(answer, cancellationToken);
        }

        // _dataService.Phrases.RemoveRange(phrase);
    }

    public async void Remove(AnswerModel answer, CancellationToken cancellationToken)
    {
        Console.WriteLine($"======= Answer{answer.Id}=======");

        var fullAnswer = await _dataService.GetFullAnswerById(answer.Id, cancellationToken);
        Console.WriteLine($"======= fullAnswer{fullAnswer.Id}=======");

        if (fullAnswer == null)
        {
            return;
        }

        foreach (var phrase in fullAnswer.Phrases)
        {
           Remove(phrase, cancellationToken);
        }

    //    _dataService.Answers.RemoveRange(answer);
    }
}