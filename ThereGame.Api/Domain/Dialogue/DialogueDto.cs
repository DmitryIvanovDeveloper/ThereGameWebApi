using System.Collections.ObjectModel;

public class DialogueDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public PhraseDto Phrase { get; set; }
}

public class AnswerDto
{
    public Guid Id { get; set; }
    public Guid ParentPhraseId { get; set; }
    public string Text { get; set; } = "";
    public string[] TensesList { get; set; } = [];
    public string[] WordsToUse { get; set; } = [];

    public ICollection<MistakeExplanationDto>  Explanations { get; set; } = new List<MistakeExplanationDto>();
    public ICollection<Translate> Translates { get; set; } = new List<Translate>();
    public ICollection<PhraseDto> Phrases { get; set; } = new List<PhraseDto>();
}

public class Translate() {
    public LanguageType Language { get; set; } = LanguageType.Russian;
    public string Text { get; set; } = "";
}

public class PhraseDto
{
    public Guid Id { get; set; }
    public Guid ParentAnswerId { get; set; }
    public string Text { get; set; } = "";
    public ICollection<AnswerDto> Answers { get; set; } = new List<AnswerDto>();
    public string[] TensesList { get; set; } = [];
    public string comments { get; set; } = "";
}

public class MistakeExplanationDto() {
    public string Word { get; set; } = "";
    public string Explanation { get; set; } = "";
}