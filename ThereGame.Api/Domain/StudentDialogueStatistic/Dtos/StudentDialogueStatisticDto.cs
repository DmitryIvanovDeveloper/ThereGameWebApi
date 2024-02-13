public class StudentDialogueStatisticDto
{
    public Guid DialogueId { get; set; }
    public Guid StudentId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<DialogueHistoryDto> DialogueHistory { get; set; } = new List<DialogueHistoryDto>();
}

public class DialogueHistoryDto
{
    public int OrderId { get; set; }
    public Guid PhraseId { get; set; }
    public string Phrase { get; set; } = "";
    public List<string> Answers { get; set; } = new List<string>();
}