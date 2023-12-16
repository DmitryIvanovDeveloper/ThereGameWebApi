namespace ThereGame.Api.Domain.Dialogue;

public class TranslateDto()
{
    public Guid AnswerParentId { get; set; }
    public Guid Id { get; set; }
    public LanguageType Language { get; set; } = LanguageType.Russian;
    public string Text { get; set; } = "";
}