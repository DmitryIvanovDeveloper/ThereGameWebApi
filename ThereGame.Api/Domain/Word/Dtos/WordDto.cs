public class WordModelDto
{
    public Guid Id { get; set; } = new Guid();
    public string Word { get; set; } = "";
    public SpeechPart[] SpeechParts { get; set; } = [];
    public string[] Pictures { get; set; } = [];
    public string Forms { get; set; } = "";
    public List<Guid> QuizlGamesId { get; set; } = new List<Guid>();

    required public WordTrasnalteDto[] TranslatesData { get; set; } = [];
}

public class WordTrasnalteDto {
    
    required public Guid Id { get; set; }
    required public Guid WordId { get; set; }
    required public LanguageType Language { get; set; }
    required public List<string> Translates { get; set; } = new List<string>();
}