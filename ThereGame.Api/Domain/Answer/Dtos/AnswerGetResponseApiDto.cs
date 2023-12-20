namespace ThereGame.Api.Domain.Dialogue;

public class AnswerGetResponseApiDto
{
    public Guid Id { get; set; }
    public Guid ParentPhraseId { get; set; }
    public string Text { get; set; } = "";
    public string[] TensesList { get; set; } = [];
    public string WordsToUse { get; set; } = "";

    public ICollection<MistakeExplanationDto> MistakeExplanations { get; set; } = new List<MistakeExplanationDto>();
    public ICollection<TranslateDto> Translates { get; set; } = new List<TranslateDto>();

    public PhraseGetResponseApiDto[] Phrases { get; set; } = [];
}

