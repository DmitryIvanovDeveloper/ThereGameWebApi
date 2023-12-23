using ThereGame.Business.Domain.Answer;
using ThereGame.Business.Domain.Dialogue;
using ThereGame.Business.Domain.Phrase;

public interface IRemoveDialogueItems
{
    void Remove(DialogueModel dialogue, CancellationToken cancellationToken);
    void Remove(PhraseModel phrase, CancellationToken cancellationToken);
    void Remove(AnswerModel answer, CancellationToken cancellationToken);
}