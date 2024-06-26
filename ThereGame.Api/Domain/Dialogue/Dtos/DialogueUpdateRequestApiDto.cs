using System.Collections.ObjectModel;
using ThereGame.Business.Domain.Student;

namespace ThereGame.Api.Domain.Dialogue;

public class DialogueUpdateRequestApiDto
{
    public Guid Id { get; set; }
    public Guid LevelId { get; set; }
    public Guid TeacherId { get; set; }
    public bool IsPublished { get; set; }
    public string VoiceSettings { get; set; } = "";
    public string Name { get; set; } = "";
    public Guid PhraseId { get; set; }
    public List<Guid> StudentsId { get; set; } = new List<Guid>();
    public List<Guid> VocabularyWordsId { get; set; } = new List<Guid>();
}