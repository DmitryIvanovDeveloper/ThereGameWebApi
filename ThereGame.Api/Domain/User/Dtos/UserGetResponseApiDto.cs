using ThereGame.Api.Domain.Dialogue;
using ThereGame.Business.Domain.Dialogue;

public class UserGetResponseApiDto() {
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
    public List<DialogueGetResponseApiDto> Dialogues { get; set; } = new List<DialogueGetResponseApiDto>();
}