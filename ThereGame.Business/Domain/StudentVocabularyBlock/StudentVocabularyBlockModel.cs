using System.Text.Json.Serialization;

namespace ThereGame.Business.Domain.Student;

public class StudentVocabularyBlockModel
{
    required public Guid Id { get; set; }
    required public Guid StudentId { get; set; }
    required public string Name { get; set; }
    required public int Order { get; set; }
    
    public List<Guid> WordsId { get; set; } = new List<Guid>();

    [JsonIgnore]
    public StudentModel? Student { get; }
}
