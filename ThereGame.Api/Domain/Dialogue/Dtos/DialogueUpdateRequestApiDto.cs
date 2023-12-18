namespace ThereGame.Api.Domain.Dialogue;

public class DialogueUpdateRequestApiDto
{
    public Guid Id { get; set; }
    public Guid LevelId { get; set; }
    public bool IsPublished { get; set; }
    public string Name { get; set; } = "";
    public Guid PhraseId { get; set; }
}