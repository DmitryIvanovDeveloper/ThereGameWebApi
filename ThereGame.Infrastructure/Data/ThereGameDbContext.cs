namespace ThereGame.Infrastructure.Data;

using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThereGame.Business.Domain.Answer;
using ThereGame.Business.Domain.Dialogue;
using ThereGame.Business.Domain.Phrase;
using ThereGame.Business.Domain.Student;
using ThereGame.Business.Domain.Teacher;
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
    public DbSet<TeacherModel> Teachers { get; set; }
    public DbSet<StudentModel> Students { get; set; }

    public async Task<DialogueModel?> GetFullDialogueById(Guid id, CancellationToken cancellationToken)
    {
        return await Dialogues.GetFullDialogueById(id, cancellationToken);
    }

    public async Task<DialogueModel[]?> GetFullDialogues(CancellationToken cancellationToken)
    {
        var dialogues = await Dialogues
            .Include(d => d.Phrase)
            .ToArrayAsync(cancellationToken)
        ;
        
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
        //<-- Teacher -->
        var teacherBuilder = modelBuilder.Entity<TeacherModel>();
        teacherBuilder.HasKey(u => u.Id);
        
        //<-- Teacher -->

        // <-- Student -->
        var studentBuilder = modelBuilder.Entity<StudentModel>();

        studentBuilder.HasKey(s => s.Id);

        studentBuilder
            .HasOne(s => s.Teacher)
            .WithMany(t => t.Students)
            .HasForeignKey(s => s.TeacherId)
            .IsRequired(false)
        ;

        // <-- Student -->

        // <-- Dialogue -->
        var dialogueBuilder = modelBuilder.Entity<DialogueModel>();

        dialogueBuilder.HasKey(d => d.Id);

        dialogueBuilder
            .HasOne(d => d.Phrase)
            .WithMany(p => p.Dialogues)
            .HasForeignKey(d => d.PhraseId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        ;

        dialogueBuilder
           .HasOne(d => d.Teacher)
           .WithMany(u => u.Dialogues)
           .HasForeignKey(d => d.TeacherId)
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
            .OnDelete(DeleteBehavior.Cascade);
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
            .OnDelete(DeleteBehavior.Cascade);
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
    }

    private async Task<DialogueModel[]> BuildDialogues(DialogueModel[] dialogues)
    {
        var buildedDialogues = new List<DialogueModel>();
        foreach (var dialogue in dialogues)
        {
            var buildedDialogue = new DialogueModel
            {
                Id = dialogue.Id,
                LevelId = dialogue.LevelId,
                Name = dialogue.Name,
                PhraseId = dialogue.Phrase.Id,
                TeacherId = dialogue.TeacherId,
                IsPublished = dialogue.IsPublished,
                IsVoiceSelected = dialogue.IsVoiceSelected,
                Phrase = await RecursiveLoad(dialogue.Phrase),
                StudentsId = dialogue.StudentsId
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
            Texts = parentAnswer.Texts,
            Tenseses = parentAnswer.Tenseses,
            WordsToUse = parentAnswer.WordsToUse,
        };

        var translates = await Translates.Where(t => t.AnswerParentId == parentAnswer.Id).ToArrayAsync();

        foreach (var translate in translates)
        {

            var buildedTranlate = new TranslateModel() 
            {
                Language = translate.Language,
                Text = translate.Text,
                Id = translate.Id,
                AnswerParentId = translate.AnswerParentId
            };
            
            buildedAnswer.Translates.Add(buildedTranlate);
        }

        var mistakeExplanations = await MistakeExplanations.Where(m => m.AnswerParentId == parentAnswer.Id).ToArrayAsync();

        foreach (var mistakeExplanation in mistakeExplanations)
        {
            var builderExplanation = new MistakeExplanationModel() 
            {
               Id = mistakeExplanation.Id,
               Word = mistakeExplanation.Word,
               Explanation = mistakeExplanation.Explanation,
               AnswerParentId = mistakeExplanation.AnswerParentId
            };

            buildedAnswer.MistakeExplanations.Add(builderExplanation);

        }

        var phrases = await Phrases.Where(p => p.ParentAnswerId == parentAnswer.Id).ToArrayAsync();
        foreach (var phrase in phrases)
        {
            var buildedPhrase = await RecursiveLoad(phrase);
            buildedAnswer.Phrases.Add(buildedPhrase);
        }

        return buildedAnswer;
    }

    public async Task<TeacherModel?> GetFullTeacherById(Guid id, CancellationToken cancellationToken)
    {
        var teacher = await Teachers.FindAsync(
            [id],
            cancellationToken: cancellationToken
        );
        if (teacher == null)
        {
            return null;
        }

        var dialogues = await GetFullDialogues(cancellationToken);

        var fullTeacher = new TeacherModel
        {
            Avatar = teacher.Avatar,
            Name = teacher.Name,
            LastName = teacher.LastName,
            Email = teacher.Email,
            Id = teacher.Id,
        };

        if (dialogues != null)
        {
            var teacherDialogues = dialogues.Where(d => d.TeacherId == id);
            foreach (var dialogue in teacherDialogues)
            {
                fullTeacher.Dialogues.Add(dialogue);
            }
        }

        var students = await Students
            .Where(student => student.TeacherId == teacher.Id)
            .ToArrayAsync()
        ;
        
        foreach (var student in students)
        {
            fullTeacher.Students.Add(student);
        }

        return fullTeacher;
    }

    public async Task RemoveDialogueCascade(Guid dialogueId, CancellationToken cancellationToken) {

        var dialogue = await Dialogues.FindAsync(dialogueId, cancellationToken);
        if (dialogue == null)
        {
            return;
        }

        await RemovePhraseCascade(dialogue.PhraseId, cancellationToken);

        Dialogues.RemoveRange(dialogue);
    }
    public async Task RemovePhraseCascade(Guid phraseId, CancellationToken cancellationToken) {
        var phrase = await Phrases.FindAsync(phraseId);
        if (phrase == null) 
        {
            return;
        }

        foreach (var answer in phrase.Answers)
        {
            await RemoveAnswerCascade(answer.Id, cancellationToken);
        }

        Phrases.RemoveRange(phrase);
    }
    public async Task RemoveAnswerCascade(Guid answerId, CancellationToken cancellationToken) {
        var answer = await Answers.FindAsync(answerId);
        if (answer == null) 
        {
            return;
        }

        foreach (var phrase in answer.Phrases)
        {   
            await RemovePhraseCascade(answer.Id, cancellationToken);
        }

        var translates = Translates.Where(translate => translate.AnswerParentId == answer.Id);
        Translates.RemoveRange(translates);

        var mistakes = MistakeExplanations.Where(mistake => mistake.AnswerParentId == answer.Id);
        MistakeExplanations.RemoveRange(mistakes);

        Answers.RemoveRange(answer);
    }
}