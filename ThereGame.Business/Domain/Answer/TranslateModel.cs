using ThereGame.Business.Domain.Answer;

public class TranslateModel
{
    public Guid Id { get; set; }
    public string Text{ get; set; } = "";
    public LanguageType Language { get; set; } = LanguageType.Russian;

    public Guid AnswerParentId { get; set; }
    public AnswerModel Answer { get; set; } = null!;
}