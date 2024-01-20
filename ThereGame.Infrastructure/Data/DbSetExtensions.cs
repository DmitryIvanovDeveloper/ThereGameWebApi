namespace ThereGame.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;
using ThereGame.Business.Domain.Answer;
using ThereGame.Business.Domain.Dialogue;
using ThereGame.Business.Domain.Phrase;

public static class DbSetExtensions
{
    public static async Task<DialogueModel?> GetFullDialogueById(
        this DbSet<DialogueModel> dialogues,
        Guid id,
        CancellationToken cancellationToken
    )
    {
        return await dialogues
            .Include(d => d.Phrase)
            .ThenInclude(p => p.Answers)
            .SingleOrDefaultAsync(d => d.Id == id, cancellationToken)
        ;
    }

    public static async Task<AnswerModel?> GetFullAnswerById(
        this DbSet<AnswerModel> answers,
        Guid id,
        CancellationToken cancellationToken
    )
    {
        return await answers
            .Include(d => d.Phrases)
            .ThenInclude(p => p.Answers)
            .Include(a => a.Translates)
            .Include(a => a.MistakeExplanations)
            .Include(a => a.Phrases)
            .SingleOrDefaultAsync(a => a.Id == id, cancellationToken)
        ;
    }

    public static async Task<PhraseModel?> GetFullPhraseById(
        this DbSet<PhraseModel> phrases,
        Guid id,
        CancellationToken cancellationToken
    )
    {
        return await phrases
            .Include(d => d.Answers)
            .ThenInclude(p => p.Phrases)
            .SingleOrDefaultAsync(a => a.Id == id, cancellationToken)
        ;
    }

    public static async Task RemoveFullDialogueById(
       this DbSet<DialogueModel> dialogues,
       Guid id,
       CancellationToken cancellationToken
    )  {
        var dialogue = await dialogues
            .Include(d => d.Phrase)
            .ThenInclude(p => p.Answers)
            .ThenInclude(a => a.Translates)
            .Include(a => a.Phrase)
            .ThenInclude(a => a.Answers)
            .ThenInclude(a => a.MistakeExplanations)
            .Include(a => a.Phrase)
            .ThenInclude(a => a.Answers)
            .ThenInclude(a => a.Phrases)
            .SingleOrDefaultAsync(d => d.Id == id, cancellationToken)
        ;
    }

    private static PhraseModel RecursiveLoad(PhraseModel parent, DbSet<PhraseModel> phrases, DbSet<AnswerModel> answers)
    {
        phrases.Entry(parent).Collection(d => d.Answers);
        //Children are loaded, we can loop them now 
        foreach (var answer in parent.Answers)
        {
            answers.Entry(answer).Reference(d => d.Phrases).Load();
            RecursiveLoad(answer, phrases, answers);
        }
        return parent;
    }

    private static AnswerModel RecursiveLoad(AnswerModel parent, DbSet<PhraseModel> phrases, DbSet<AnswerModel> answers)
    {
        answers.Entry(parent).Collection(d => d.Phrases);
        foreach (var phrase in parent.Phrases)
        {
            phrases.Entry(phrase).Reference(d => d.Answers).Load();
            RecursiveLoad(phrase, phrases, answers);
        }
        return parent;
    }
}