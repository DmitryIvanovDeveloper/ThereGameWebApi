using ThereGame.Business.Domain.Answer;

public class TranslateModel() {
    public Guid Id { get; set; }
    public string Text{ get; set; }
    public LanguageType Language { get; set; }

    public Guid AnswerId { get; set; }
    public AnswerModel Answer { get; set; }
}