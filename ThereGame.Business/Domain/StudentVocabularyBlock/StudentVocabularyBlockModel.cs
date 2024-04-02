using System.Text.Json.Serialization;

namespace ThereGame.Business.Domain.Student;

public class StudentVocabularyBlockModel
{
    required public Guid Id { get; set; }
    required public Guid StudentId { get; set; }
    required public string Name { get; set; }
    required public DateTime CreatedAt { get; set; }
    
    public List<Guid> WordsId { get; set; } = new List<Guid>();

    public Guid DialogueId { get; set; }

    [JsonIgnore]
    public StudentModel? Student { get; }

    public ICollection<QuizlGameStatisticModel> QuizlGameStatistics { get; } = new List<QuizlGameStatisticModel>();
    public ICollection<TranslateWordsGameStatisticModel> TranslateWordsGameStatistics { get; } = new List<TranslateWordsGameStatisticModel>();
    public ICollection<BuildWordsGameStatisticModel> BuildWordsGameStatistics { get; } = new List<BuildWordsGameStatisticModel>();
}
