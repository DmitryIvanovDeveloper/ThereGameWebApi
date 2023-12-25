namespace ThereGame.Business.Domain.Dialogue;

using ThereGame.Business.Domain.Phrase;

public class DialogueModel
{
    public Guid Id { get; set; }
    public Guid LevelId { get; set; }
    public Guid? PhraseId { get; set; }

    public string Name { get; set; } = "";
    public bool IsPublished { get; set; }
    public bool IsVoiceSelected { get; set; }

    public PhraseModel? Phrase { get; set; } = null;
}
