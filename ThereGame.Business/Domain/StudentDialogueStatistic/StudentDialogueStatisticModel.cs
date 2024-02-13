using ThereGame.Business.Domain.Student;

public class StudentDialogueStatisticModel
{
    public Guid Id { get; set; } = new Guid();
    public Guid DialogueId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<DialogueHistory> DialogueHistories { get; set; } = new List<DialogueHistory>();

    public Guid StudentId { get; set; }
    public StudentModel? Student { get; set; }
}

public class DialogueHistory
{
    public int OrderId { get; set; }
    public Guid Id { get; set; } = new Guid();
    public Guid PhraseId { get; set; }
    public string Phrase { get; set; } = "";
    public List<string> Answers { get; set; } = new List<string>();

    public StudentDialogueStatisticModel? StudentDialogueStatistic { get; set; }
    public Guid StudentDialogueStatisticId { get; set; }
}