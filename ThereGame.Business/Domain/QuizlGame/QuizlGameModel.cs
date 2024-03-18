public class QuizlGameModel {
    public Guid Id { get; set; }
    public Guid TeacherId { get; set; }
    public Guid HiddenWordId { get; set; }
    public string Data { get; set; } = "";
}