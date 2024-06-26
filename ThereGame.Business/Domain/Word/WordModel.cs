using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ThereGame.Business.Domain.Word;

public class WordModel 
{
    public Guid Id { get; set; } = new Guid();
    public string Word { get; set; } = "";
    public string[] Pictures { get; set; } = [];
    public SpeechPart[] SpeechParts { get; set; } = [];
    public string Forms { get; set; } = "";
    public List<WordTrasnalteModel> Translates { get; set; } = new List<WordTrasnalteModel>();
    public List<Guid> QuizlGamesId { get; set; } = new List<Guid>();
}

public class WordTrasnalteModel {
    
    public Guid Id { get; set; }
    public LanguageType Language { get; set; }
    public List<string> Translates { get; set; } = new List<string>();

    public Guid WordId { get; set; }
    [JsonIgnore]
    public WordModel? Word { get; } = null;
}

public class WordCategory
{
    public Guid Id { get; set; } = new Guid();
    public string Name { get; set; } = "";

    [JsonIgnore]
    public ICollection<Guid> Words{ get; } = new List<Guid>();
}
