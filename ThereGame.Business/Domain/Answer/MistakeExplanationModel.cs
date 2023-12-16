namespace ThereGame.Business.Domain.Answer;

public class MistakeExplanationModel
{
    public Guid Id { get; set; }
    public string Text { get; set; } = "";
    public string Explanation { get; set; } = "";

    public Guid AnswerParentId { get; set; }
    public AnswerModel Answer { get; set; } = null!;
}
