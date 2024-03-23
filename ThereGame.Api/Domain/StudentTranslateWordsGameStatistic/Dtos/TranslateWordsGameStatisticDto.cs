public class TranslateWordsGameStatisticDto
{
    required public Guid WordId { get; set; }
    required public Guid VocabularyBlockId { get; set; }

    required public List<string> Answers { get; set; }
}