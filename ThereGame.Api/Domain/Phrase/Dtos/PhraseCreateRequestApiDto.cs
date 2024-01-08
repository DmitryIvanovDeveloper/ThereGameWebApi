namespace ThereGame.Api.Domain.Phrase.Dtos;

public class PhraseCreateRequestApiDto
{
    public Guid Id { get; set; }
    public string Text { get; set; } = "";
    public string Comments { get; set; } = "";
    public required AudioSettingsModel AudioSettings { get; set; }
    public string[] Tenses { get; set; } = [];
    public Guid? ParentAnswerId { get; set; } = null;
}