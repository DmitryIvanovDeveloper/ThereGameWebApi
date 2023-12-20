public class MistakeExplanationDto()
{
    public Guid AnswerParentId { get; set; }
    public Guid Id { get; set; }
    public string Word { get; set; } = "";
    public string Explanation { get; set; } = "";
}
