using System.Collections.ObjectModel;
using ThereGame.Api.Domain.Phrase.Dtos;

namespace ThereGame.Api.Domain.Dialogue;

public class DialogueCreateRequestApiDto
{
    public Guid Id { get; set; }
    public Guid LevelId { get; set; }
    public Guid TeacherId { get; set; }
    public bool IsPublished { get; set; }
    public bool IsVoiceSelected { get; set; }
    public string Name { get; set; } = "";
    public PhraseCreateRequestApiDto Phrase { get; set; } = null!;
    public List<Guid> StudentsId { get; set; } = new List<Guid>();
}