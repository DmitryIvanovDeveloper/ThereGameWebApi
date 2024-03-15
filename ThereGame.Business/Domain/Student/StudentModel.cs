namespace ThereGame.Business.Domain.Student;

using System.Text.Json.Serialization;
using ThereGame.Business.Domain.Teacher;

public class StudentModel 
{
    public Guid Id { get; set; }
    public string Avatar { get; set; } = "";
    public string Name { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";
    public DateTime CreatedAt { get; set; }

    public Guid? TeacherId { get; set; } = null;
    public TeacherModel? Teacher { get; set; } = null;

    [JsonIgnore]
    public List<StudentVocabularyBlockModel> VocabularyBlocks { get; set; } = new List<StudentVocabularyBlockModel>();

    [JsonIgnore]
    public ICollection<StudentDialogueStatisticModel> DialoguesStatistic { get; } = new List<StudentDialogueStatisticModel>();
}