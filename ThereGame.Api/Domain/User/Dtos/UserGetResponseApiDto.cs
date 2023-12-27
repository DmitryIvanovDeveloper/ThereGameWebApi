using ThereGame.Api.Domain.Dialogue;

public class UserGetResponseApiDto() {
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
    public List<DialogueGetResponseApiDto> Dialogues { get; set; } = new List<DialogueGetResponseApiDto>();
    public List<StudentGetResponseDto> Students { get; set; } = new List<StudentGetResponseDto>();
}