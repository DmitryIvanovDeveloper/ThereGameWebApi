public class WordModelDto
{
    public Guid Id { get; set; } = new Guid();
    public string Word { get; set; } = "";
    public SpeechPart SpeechPart { get; set; } = SpeechPart.Unknown;
    public string[] Pictures { get; set; } = [];
    required public WordTrasnalteDto[] TranslatesData { get; set; } = [];
}

public class WordTrasnalteDto {
    
    required public Guid Id { get; set; }
    required public Guid WordId { get; set; }
    required public LanguageType Language { get; set; }
    required public List<string> Translates { get; set; } = new List<string>();
}