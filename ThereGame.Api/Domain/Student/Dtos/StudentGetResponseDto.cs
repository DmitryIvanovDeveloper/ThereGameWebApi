using ThereGame.Api.Domain.Dialogue;

public class StudentGetResponseDto 
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
    public List<DialogueGetResponseApiDto> Dialogues { get; set; } = new List<DialogueGetResponseApiDto>();
}