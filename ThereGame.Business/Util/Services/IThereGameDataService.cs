namespace ThereGame.Business.Util.Services;

using Microsoft.EntityFrameworkCore;
using ThereGame.Business.Domain.Answer;
using ThereGame.Business.Domain.Dialogue;
using ThereGame.Business.Domain.Phrase;


public interface IThereGameDataService
{
    DbSet<PhraseModel> Phrases { get; }
    DbSet<AnswerModel> Answers { get; }
    DbSet<TranslateModel> Translates { get; }
    DbSet<MistakeExplanationModel> MistakeExplanations { get; }
    DbSet<DialogueModel> Dialogues { get; }
    
    Task<DialogueModel?> GetFullDialogueById(Guid id, CancellationToken cancellationToken);
    Task<PhraseModel?> GetFullPhraseById(Guid id, CancellationToken cancellationToken);
    Task<AnswerModel?> GetFullAnswerById(Guid id, CancellationToken cancellationToken);
    Task RemoveFullDialogueById(Guid id, CancellationToken cancellationToken);
    Task<DialogueModel[]?> GetFullDialogues(CancellationToken cancellationToken);
    Task SaveChanges(CancellationToken cancellationToken);
}
