namespace ThereGame.Business.Util.Services;

using Microsoft.EntityFrameworkCore;
using ThereGame.Business.Domain.Answer;
using ThereGame.Business.Domain.Dialogue;
using ThereGame.Business.Domain.Phrase;
using ThereGame.Business.Domain.Student;
using ThereGame.Business.Domain.Teacher;
using ThereGame.Business.Domain.Word;

public interface IThereGameDataService
{
    DbSet<PhraseModel> Phrases { get; }
    DbSet<AnswerModel> Answers { get; }
    DbSet<TranslateModel> Translates { get; }
    DbSet<MistakeExplanationModel> MistakeExplanations { get; }
    DbSet<AudioSettingsModel> AudioSettings { get; }
    DbSet<TeacherModel> Teachers { get; }
    DbSet<StudentModel> Students { get; }
    DbSet<DialogueModel> Dialogues { get; } 
    DbSet<StudentDialogueStatisticModel> StudentDialoguesStatistics { get; }
    DbSet<DialogueHistory> DialogueHistories { get; }
    DbSet<WordModel> Words { get; set; }
    DbSet<WordTrasnalteModel> WordTranslates { get; set; }
    DbSet<StudentVocabularyBlockModel> StudentsVocabularyBlocks { get; set; }
    DbSet<QuizlGameModel> QuizlGame { get; set; }
    
    Task<DialogueModel?> GetFullDialogueById(Guid id, CancellationToken cancellationToken);
    Task<PhraseModel?> GetFullPhraseById(Guid id, CancellationToken cancellationToken);
    Task<AnswerModel?> GetFullAnswerById(Guid id, CancellationToken cancellationToken);
    Task<TeacherModel?> GetFullTeacherById(Guid id, CancellationToken cancellationToken);

    Task RemoveFullDialogueById(Guid id, CancellationToken cancellationToken);
    Task<DialogueModel[]?> GetFullDialogues(CancellationToken cancellationToken);
    Task SaveChanges(CancellationToken cancellationToken);
    Task RemoveDialogueCascade(Guid dialogueId, CancellationToken cancellationToken);
    Task RemovePhraseCascade(Guid phraseId, CancellationToken cancellationToken);
    Task RemoveAnswerCascade(Guid answerId, CancellationToken cancellationToken);
}
