public class QuizlGameStatisticDto
{
    required public Guid QuizlGameId { get; set; }
    required public Guid VocabularyBlockId { get; set; }

    required public List<string> Answers { get; set; }
}