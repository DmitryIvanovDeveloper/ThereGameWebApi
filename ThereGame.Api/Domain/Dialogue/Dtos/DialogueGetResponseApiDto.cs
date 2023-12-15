namespace ThereGame.Api.Domain.Dialogue;

public class DialogueGetResponseApiDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public Guid? PhraseId { get; set; }
}