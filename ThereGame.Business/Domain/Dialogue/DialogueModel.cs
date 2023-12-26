namespace ThereGame.Business.Domain.Dialogue;

using ThereGame.Business.Domain.Phrase;
using ThereGame.Business.Domain.User;

public class DialogueModel
{
    public Guid Id { get; set; }
    public Guid LevelId { get; set; }

    public string Name { get; set; } = "";
    public bool IsPublished { get; set; }
    public bool IsVoiceSelected { get; set; }

    public Guid UserId { get; set; }
    public UserModel User { get; set; } = null!;

    public Guid PhraseId { get; set; }
    public PhraseModel Phrase { get; set; } = null!;
}
