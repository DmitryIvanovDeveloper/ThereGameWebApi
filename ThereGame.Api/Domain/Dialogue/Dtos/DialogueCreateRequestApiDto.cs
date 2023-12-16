namespace ThereGame.Api.Domain.Dialogue;

public class DialogueCreateRequestApiDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public PhraseGetRequestApiDto? Phrase { get; set; } = null;
}