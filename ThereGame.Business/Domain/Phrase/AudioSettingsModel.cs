using System.Text.Json.Serialization;
using ThereGame.Business.Domain.Phrase;

public class AudioSettingsModel
{
    public Guid Id { get; set; }
    public string GenerationSettings { get; set; } = "";
    public string AudioData { get; set; } = "";
    public int Revision { get; set; }

    
    public Guid? ParentPhraseId { get; set; } = null;
    [JsonIgnore]
    public PhraseModel? ParentPhrase { get; set; } = null;
}