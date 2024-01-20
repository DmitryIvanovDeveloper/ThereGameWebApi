using ThereGame.Api.Domain.Phrase.Dtos;

namespace ThereGame.Api.Domain.Dialogue;

public class DialogueGetResponseApiDto
{
    public Guid Id { get; set; }
    public Guid TeacherId { get; set; }
    public Guid LevelId { get; set; }
    public Guid PhraseId { get; set; }
    public bool IsPublished { get; set; }
    public string VoiceSettings { get; set; } = "";
    public string Name { get; set; } = "";
    public List<Guid> StudentsId { get; set; } = new List<Guid>();

    public PhraseGetResponseApiDto? Phrase { get; set; } = null;
}