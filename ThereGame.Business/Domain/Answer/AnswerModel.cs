namespace ThereGame.Business.Domain.Answer;

using ThereGame.Business.Domain.Phrase;


public class AnswerModel
{
    public Guid Id { get; set; }
    public string Text { get; set; } = "";

    public Guid PhraseId { get; set; }
    public PhraseModel Phrase { get; set; } = null!;
    
    public ICollection<PhraseModel> Phrases { get; } = new List<PhraseModel>();
}
