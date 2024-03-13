using ThereGame.Business.Domain.Word;

namespace ThereGame.Api.Domain.Student;

public class UpdateStudentVocabularyRequestApiDto
{
    required public Guid TeacherId { get; set; }
    required public Guid StudentId { get; set; }
    required public WordModelDto WordData { get; set; }
}


public class WordModelDto
{
    public Guid Id { get; set; } = new Guid();
    public string Word { get; set; } = "";
    required public WordTrasnalteDto[]? TranslatesData { get; set; } = [];
}

public class WordTrasnalteDto {
    
    required public Guid Id { get; set; }
    required public Guid WordId { get; set; }
    required public LanguageType Language { get; set; }
    required public List<string> Translates { get; set; } = new List<string>();
}