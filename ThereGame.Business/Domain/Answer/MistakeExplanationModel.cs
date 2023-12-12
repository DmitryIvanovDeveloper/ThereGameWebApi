namespace ThereGame.Business.Domain.Answer;

public class MistakeExplanationModel
{
    public Guid Id { get; set; }
    public string Text { get; set; } = "";
    public string Explanation { get; set; }

    public Guid AnswerId { get; set; }
    public AnswerModel Answer { get; set; }
}
