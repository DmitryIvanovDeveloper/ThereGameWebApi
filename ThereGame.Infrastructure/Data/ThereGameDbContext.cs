namespace ThereGame.Infrastructure.Data;

using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThereGame.Business.Domain.Answer;
using ThereGame.Business.Domain.Dialogue;
using ThereGame.Business.Domain.Phrase;
using ThereGame.Business.Util.Services;

public class ThereGameDbContext : DbContext, IThereGameDataService
{
    protected ThereGameDbContext()
    { }
    public ThereGameDbContext(DbContextOptions options)
        : base(options)
    { }


    public DbSet<PhraseModel> Phrases { get; set; }
    public DbSet<AnswerModel> Answers { get; set; }
    public DbSet<DialogueModel> Dialogues { get; set; }
    public DbSet<TranslateModel> Translates { get; set; }
    public DbSet<MistakeExplanationModel> MistakeExplanations { get; set; }
    public DbSet<UserModel> Users { get; set; }

    public async Task<DialogueModel?> GetFullDialogueById(Guid id, CancellationToken cancellationToken)
    {
        return await Dialogues.GetFullDialogueById(id, cancellationToken);
    }

    public async Task<DialogueModel[]?> GetFullDialogues(CancellationToken cancellationToken)
    {
        var dialogues = await Dialogues.Include(d => d.Phrase).ToArrayAsync(cancellationToken);
        return await BuildDialogues(dialogues);
    }

    public async Task RemoveFullDialogueById(Guid id, CancellationToken cancellationToken)
    {
        await Dialogues.RemoveFullDialogueById(id, cancellationToken);
    }

    public async Task<AnswerModel?> GetFullAnswerById(Guid id, CancellationToken cancellationToken)
    {
        return await Answers.GetFullAnswerById(id, cancellationToken);
    }
    public async Task<PhraseModel?> GetFullPhraseById(Guid id, CancellationToken cancellationToken)
    {
        return await Phrases.GetFullPhraseById(id, cancellationToken);
    }
    async Task IThereGameDataService.SaveChanges(CancellationToken cancellationToken)
    {
        await SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // <-- Dialogue -->
        var dialogueBuilder = modelBuilder.Entity<DialogueModel>();

        dialogueBuilder.HasKey(d => d.Id);

        dialogueBuilder
            .HasOne(d => d.Phrase)
            .WithMany(p => p.Dialogues)
            .HasForeignKey(d => d.PhraseId)
            .IsRequired()
        ;

        dialogueBuilder
           .HasOne(d => d.User)
           .WithMany(u => u.Dialogues)
           .HasForeignKey(d => d.UserId)
           .IsRequired()
       ;
        // </- Dialogue -->


        // <-- Phrase -->
        var phraseBuilder = modelBuilder.Entity<PhraseModel>();

        phraseBuilder.HasKey(p => p.Id);

        phraseBuilder
            .HasOne(p => p.ParentAnswer)
            .WithMany(a => a.Phrases)
            .HasForeignKey(p => p.ParentAnswerId)
            .IsRequired(false)
        ;

        phraseBuilder.Property(p => p.ParentAnswerId).IsRequired(false);
        // </- Phrase -->

        // <-- MistakeExplanations -->
        var mistakeExplanationBuilder = modelBuilder.Entity<MistakeExplanationModel>();

        mistakeExplanationBuilder.HasKey(m => m.Id);
        // </- MistakeExplanations -->

        // <-- Translates -->
        var transaleBuilder = modelBuilder.Entity<TranslateModel>();

        transaleBuilder.HasKey(m => m.Id);
        // </- Translates -->

        // <-- Answer -->
        var answerBuilder = modelBuilder.Entity<AnswerModel>();

        answerBuilder.HasKey(p => p.Id);

        answerBuilder
            .HasOne(a => a.ParentPhrase)
            .WithMany(p => p.Answers)
            .HasForeignKey(a => a.ParentPhraseId)
            .IsRequired()
        ;

        answerBuilder
            .HasMany(a => a.MistakeExplanations)
            .WithOne(m => m.Answer)
            .HasForeignKey(m => m.AnswerParentId)
            .IsRequired()
        ;

        answerBuilder
            .HasMany(a => a.Translates)
            .WithOne(t => t.Answer)
            .HasForeignKey(t => t.AnswerParentId)
            .IsRequired()
        ;
        // <-- Answer -->

        //<-- User  -->

        var userBuilder = modelBuilder.Entity<UserModel>();
        answerBuilder.HasKey(u => u.Id);

        //<-- User  -->

    }

    private async Task<DialogueModel[]> BuildDialogues(DialogueModel[] dialogues)
    {
        var buildedDialogues = new List<DialogueModel>();
        foreach (var dialogue in dialogues)
        {
            var buildedDialogue = new DialogueModel()
            {
                Id = dialogue.Id,
                LevelId = dialogue.LevelId,
                Name = dialogue.Name,
                PhraseId = dialogue.Phrase?.Id,
                UserId = dialogue.UserId,
                IsVoiceSelected = dialogue.IsVoiceSelected,
                Phrase = await RecursiveLoad(dialogue.Phrase),
            };

            buildedDialogues.Add(buildedDialogue);
        }

        return buildedDialogues.ToArray();
    }

    private async Task<PhraseModel> RecursiveLoad(PhraseModel parentPhrase)
    {
        var buildedPhrase = new PhraseModel()
        {
            Id = parentPhrase.Id,
            ParentAnswerId = parentPhrase.ParentAnswerId,
            Text = parentPhrase.Text,
            Comments = parentPhrase.Comments,
            Tenseses = parentPhrase.Tenseses,
            AudioData = parentPhrase.AudioData,
        };

        var answers = await Answers.Where(a => a.ParentPhraseId == parentPhrase.Id).ToArrayAsync();
        foreach (var answer in answers)
        {
            var buildedAnswer = await RecursiveLoad(answer);
            buildedPhrase.Answers.Add(buildedAnswer);
        }

        return buildedPhrase;
    }

    private async Task<AnswerModel> RecursiveLoad(AnswerModel parentAnswer)
    {
        var buildedAnswer = new AnswerModel()
        {
            ParentPhraseId = parentAnswer.ParentPhraseId,
            Id = parentAnswer.Id,
            Text = parentAnswer.Text,
            Tenseses = parentAnswer.Tenseses,
            WordsToUse = parentAnswer.WordsToUse,
            Translates = parentAnswer.Translates,
            MistakeExplanations = parentAnswer.MistakeExplanations,
        };

        var phrases = await Phrases.Where(p => p.ParentAnswerId == parentAnswer.Id).ToArrayAsync();

        foreach (var phrase in phrases)
        {
            var buildedPhrase = await RecursiveLoad(phrase);
            buildedAnswer.Phrases.Add(buildedPhrase);
        }

        return buildedAnswer;
    }
}