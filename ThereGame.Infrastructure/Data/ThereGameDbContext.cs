namespace Inspirer.Infrastructure.Data;

using System.Threading.Tasks;
using Inspirer.Business.Util.Services;
using Microsoft.EntityFrameworkCore;
using ThereGame.Business.Domain.Answer;
using ThereGame.Business.Domain.Dialogue;
using ThereGame.Business.Domain.Phrase;

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
            .HasOne(p => p.Answer)
            .WithMany(a => a.Phrases)
            .HasForeignKey(p => p.AnswerId)
            .IsRequired()
        ;
        // </- Phrase -->


        // <-- Answer -->
        var answerBuilder = modelBuilder.Entity<AnswerModel>();

        answerBuilder.HasKey(p => p.Id);

        answerBuilder
            .HasOne(a => a.Phrase)
            .WithMany(p => p.Answers)
            .HasForeignKey(a => a.PhraseId)
            .IsRequired()
        ;
        // </- Answer -->
    }
}