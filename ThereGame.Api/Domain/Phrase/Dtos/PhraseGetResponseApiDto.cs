namespace ThereGame.Api.Domain.Phrase.Dtos;

using ThereGame.Api.Domain.Dialogue;

public class PhraseGetResponseApiDto
{
    public Guid Id { get; set; }
    public Guid? ParentAnswerId { get; set; }
    public string Text { get; set; } = "";
    public string[] TensesList { get; set; } = [];
    public string Comments { get; set; } = "";
    public string AudioData { get; set; } = "";
    public string AudioGenerationSettings { get; set; } = "";
    public ICollection<AnswerGetResponseApiDto> Answers { get; set; } = new List<AnswerGetResponseApiDto>();
}