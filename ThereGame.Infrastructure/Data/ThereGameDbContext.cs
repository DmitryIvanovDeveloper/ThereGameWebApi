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
    
    public async Task<DialogueModel?> GetFullDialogueById(Guid id, CancellationToken cancellationToken)
    {
        return await Dialogues.GetFullDialogueById(id, cancellationToken);
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
            .HasForeignKey(m => m.AnswerId)
            .IsRequired()
        ;

        answerBuilder
            .HasMany(a => a.Translates)
            .WithOne(t => t.Answer)
            .HasForeignKey(t => t.AnswerId)
            .IsRequired()
        ;
        // </- Answer -->
    }

}