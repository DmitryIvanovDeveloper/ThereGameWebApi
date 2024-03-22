using System.Text.Json.Serialization;
using ThereGame.Business.Domain.Student;

public class QuizlGameStatisticModel
{
    public Guid Id { get; set; } = new Guid();
    public Guid QuizlGameId { get; set; }
    public List<string> Answers { get; set; } = new List<string>();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Guid VocabularyBlockId { get; set; }
    [JsonIgnore]
    public StudentVocabularyBlockModel? VocabularyBlock { get; }
}