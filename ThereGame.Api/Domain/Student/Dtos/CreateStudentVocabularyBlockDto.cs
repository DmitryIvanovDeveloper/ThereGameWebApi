using ThereGame.Business.Domain.Student;

namespace ThereGame.Api.Domain.Student;

public class CreateStudentVocabularyBlockDto
{
    required public Guid Id { get; set; }
    required public string Name { get; set; } = "";
    required public Guid StudentId { get; set; }
}


