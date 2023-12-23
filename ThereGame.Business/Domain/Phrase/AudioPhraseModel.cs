using ThereGame.Business.Domain.Phrase;

public class AudioPhrase
{
    public Guid Id { get; set; }
    public string Data { get; set; } = "";

    public Guid ParentPhraseId { get; set; }
    public PhraseModel ParentPhrase { get; set; }
}