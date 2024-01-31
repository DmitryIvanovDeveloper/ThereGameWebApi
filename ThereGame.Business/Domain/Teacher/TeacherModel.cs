namespace ThereGame.Business.Domain.Teacher;

using System.Text.Json.Serialization;
using ThereGame.Business.Domain.Dialogue;
using ThereGame.Business.Domain.Student;

public class TeacherModel 
{
    public Guid Id { get; set; }
    public string Avatar { get; set; } = "";
    public string Name { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";
    public DateTime CreatedAt { get; set; }

    [JsonIgnore]
    public ICollection<DialogueModel> Dialogues { get; } = new List<DialogueModel>();
    [JsonIgnore]
    public ICollection<StudentModel> Students { get; } = new List<StudentModel>();
}