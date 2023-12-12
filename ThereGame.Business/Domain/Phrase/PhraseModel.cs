namespace ThereGame.Business.Domain.Phrase;

using ThereGame.Business.Domain.Answer;
using ThereGame.Business.Domain.Dialogue;


public class PhraseModel
{
    public Guid Id { get; set; }
    public string Text { get; set; } = "";
    public string Comments { get; set; } = "";
    public string[] Tenses { get; set; } = [];


    public Guid ParentAnswerId { get; set; }
    public AnswerModel? ParentAnswer { get; set; } = null;


    public ICollection<AnswerModel> Answers { get; } = new List<AnswerModel>();
    public ICollection<DialogueModel> Dialogues { get; } = new List<DialogueModel>();
}
