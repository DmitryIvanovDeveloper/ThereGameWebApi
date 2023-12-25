namespace ThereGame.Api.Domain.Dialogue;

public class DialogueGetResponseApiDto
{
    public Guid Id { get; set; }
    public bool IsPublished { get; set; }
    public bool IsVoiceSelected { get; set; }
    public Guid LevelId { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; } = "";
    public Guid? PhraseId { get; set; }

    public PhraseGetResponseApiDto? Phrase { get; set; } = null;
}