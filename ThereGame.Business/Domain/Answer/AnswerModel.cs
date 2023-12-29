namespace ThereGame.Business.Domain.Answer;

using ThereGame.Business.Domain.Phrase;


public class AnswerModel
{
    public Guid Id { get; set; }
    public string[] Texts { get; set; } = [];
    public string[] Tenseses { get; set; } = [];
    public string WordsToUse { get; set; } = "";

    public Guid ParentPhraseId { get; set; }
    public PhraseModel ParentPhrase { get; set; } = null!;
    
    public ICollection<TranslateModel> Translates { get; set; } = new List<TranslateModel>();
    public ICollection<MistakeExplanationModel> MistakeExplanations { get; set; } = new List<MistakeExplanationModel>();
    public ICollection<PhraseModel> Phrases { get; } = new List<PhraseModel>();
}
