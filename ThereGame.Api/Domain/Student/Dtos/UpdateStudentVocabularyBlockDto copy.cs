using ThereGame.Business.Domain.Student;

namespace ThereGame.Api.Domain.Student;

public class UpdateStudentVocabularyBlockDto
{
    required public Guid Id { get; set; }
    required public Guid StudentId { get; set; }
    required public string Name { get; set; }
    required public int Order { get; set; }
    required public List<Guid> WordsId { get; set; } = new List<Guid>();
}


