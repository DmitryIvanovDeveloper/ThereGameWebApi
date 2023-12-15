public class PhraseGetResponseApiDto
{
    public Guid Id { get; set; }
    public Guid? ParentAnswerId { get; set; }
    public string Text { get; set; } = "";
    public string[] TensesList { get; set; } = [];
    public string Comments { get; set; } = "";
}