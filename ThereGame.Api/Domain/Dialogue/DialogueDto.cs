using Newtonsoft.Json;

namespace ThereGame.Api.Domain.Dialogue;


public class DialogueCreateRequestApiDto
{
    [JsonProperty("Id")]
    public Guid Id { get; set; }
    [JsonProperty("Name")]
    public string Name { get; set; } = "";
    [JsonProperty("PhraseId")]
    public Guid PhraseId { get; set; }
}

public class DialogueGetResponseApiDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public PhraseGetResponseApiDto? Phrase { get; set; }
}

public class AnswerGetResponseApiDto
{
    public Guid Id { get; set; }
    public Guid ParentPhraseId { get; set; }
    public string Text { get; set; } = "";
    public string[] TensesList { get; set; } = [];
    public string[] WordsToUse { get; set; } = [];

    public ICollection<MistakeExplanationGetResponseApiDto> Explanations { get; set; } = new List<MistakeExplanationGetResponseApiDto>();
    public ICollection<Translate> Translates { get; set; } = new List<Translate>();
    public ICollection<PhraseGetResponseApiDto> Phrases { get; set; } = new List<PhraseGetResponseApiDto>();
}

public class Translate()
{
    public LanguageType Language { get; set; } = LanguageType.Russian;
    public string Text { get; set; } = "";
}

public class PhraseGetResponseApiDto
{
    public Guid Id { get; set; }
    public Guid ParentAnswerId { get; set; }
    public string Text { get; set; } = "";
    public ICollection<AnswerGetResponseApiDto> Answers { get; set; } = new List<AnswerGetResponseApiDto>();
    public string[] TensesList { get; set; } = [];
    public string comments { get; set; } = "";
}

public class MistakeExplanationGetResponseApiDto()
{
    public string Word { get; set; } = "";
    public string Explanation { get; set; } = "";
}
