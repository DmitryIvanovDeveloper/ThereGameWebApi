using System.Text.Json.Serialization;
using ThereGame.Business.Domain.Dialogue;

public class UserModel 
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";

    [JsonIgnore]
    public ICollection<DialogueModel> Dialogues { get; } = new List<DialogueModel>();
}