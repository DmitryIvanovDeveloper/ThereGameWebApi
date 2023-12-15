namespace ThereGame.Api.Domain.Dialogue;

public class TranslateDto()
{
    public LanguageType Language { get; set; } = LanguageType.Russian;
    public string Text { get; set; } = "";
}