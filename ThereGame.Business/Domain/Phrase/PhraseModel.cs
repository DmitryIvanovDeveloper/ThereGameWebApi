namespace ThereGame.Business.Domain.Phrase;

using ThereGame.Business.Domain.Answer;
using ThereGame.Business.Domain.Dialogue;


public class PhraseModel
{
    public Guid Id { get; set; }
    public string Text { get; set; } = "";

    public Guid AnswerId { get; set; }
    public AnswerModel? Answer { get; set; } = null;

    public ICollection<AnswerModel> Answers { get; } = new List<AnswerModel>();
    public ICollection<DialogueModel> Dialogues { get; } = new List<DialogueModel>();
}
