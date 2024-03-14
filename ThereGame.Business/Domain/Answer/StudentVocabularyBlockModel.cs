namespace ThereGame.Business.Domain.Student;

public class StudentVocabularyBlockModel
{
    public Guid Id { get; set; }
    public Guid studentId { get; set; }

    public List<Guid> WordsId { get; set; } = new List<Guid>();
}
