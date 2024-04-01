namespace ThereGame.Business.Domain.Dialogue;

using ThereGame.Business.Domain.Phrase;
using ThereGame.Business.Domain.Teacher;

public class DialogueModel
{
    public Guid Id { get; set; }
    public Guid LevelId { get; set; }

    public string Name { get; set; } = "";
    public bool IsPublished { get; set; }
    public string VoiceSettings { get; set; } = "";

    public Guid TeacherId { get; set; }
    public TeacherModel Teacher { get; set; } = null!;
    
    public Guid PhraseId { get; set; }
    public PhraseModel Phrase { get; set; } = null!;
    
    public List<Guid> StudentsId { get; set; } = new List<Guid>();
    public List<Guid> VocabularyWordsId { get; set; } = new List<Guid>();
}
