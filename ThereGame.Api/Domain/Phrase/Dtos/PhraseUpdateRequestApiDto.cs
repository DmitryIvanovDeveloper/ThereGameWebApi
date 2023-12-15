public class PhraseUpdateRequestApiDto
{
    public Guid Id { get; set; }
    public string Text { get; set; } = "";
    public string Comments { get; set; } = "";
    public string[] Tenses { get; set; } = [];
    public Guid? ParentAnswerId { get; set; } = null;
}