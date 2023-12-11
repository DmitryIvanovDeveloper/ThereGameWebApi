namespace ThereGame.Business.Domain.Dialogue;

using ThereGame.Business.Domain.Phrase;


public class DialogueModel
{
    public Guid Id { get; set; }

    public Guid PhraseId { get; set; }
    public PhraseModel? Phrase { get; set; } = null;
}
