public class DialogueDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public PhraseDto Phrase { get; set; }
}

public class AnswerDto
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public string[] TensesList { get; set; }
    public string[] WordsToUse { get; set; }

    public MistakeExplanationDto[]  Explanations { get; set; }
    public Translate[] Translates { get; set; }
    public PhraseDto[] Phrases { get; set; }
}

public class Translate() {
    public LanguageType Language { get; set; }
    public string Text { get; set; }
}

public class PhraseDto
{
    public Guid Id { get; set; }
    public string ParentAnswerId { get; set; }
    public string Text { get; set; }
    public AnswerDto[] Answers { get; set; }
    public string[] TensesList { get; set; }
    public string comments { get; set; }
}

public class MistakeExplanationDto() {
    public string Word { get; set; }
    public string Explanation { get; set; }
}