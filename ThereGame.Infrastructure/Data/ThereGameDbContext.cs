namespace ThereGame.Infrastructure.Data;

using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThereGame.Business.Domain.Answer;
using ThereGame.Business.Domain.Dialogue;
using ThereGame.Business.Domain.Phrase;
using ThereGame.Business.Domain.Student;
using ThereGame.Business.Domain.Teacher;
using ThereGame.Business.Domain.Word;
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
    public DbSet<AudioSettingsModel> AudioSettings { get; set; }
    public DbSet<TranslateModel> Translates { get; set; }
    public DbSet<MistakeExplanationModel> MistakeExplanations { get; set; }
    public DbSet<TeacherModel> Teachers { get; set; }
    public DbSet<StudentModel> Students { get; set; }
    public DbSet<StudentDialogueStatisticModel> StudentDialoguesStatistics { get; set; }
    public DbSet<DialogueHistory> DialogueHistories { get; set; }
    public DbSet<WordModel> Words { get; set; }
    public DbSet<WordTrasnalteModel> WordTranslates { get; set; }
    public DbSet<StudentVocabularyBlockModel> StudentsVocabularyBlocks { get; set; }
    public DbSet<QuizlGameModel> QuizlGame { get; set; }
    public DbSet<QuizlGameStatisticModel> QuizlGameStatistics { get; set; }
    public DbSet<TranslateWordsGameStatisticModel> TranslateWordsGameStatistics { get; set; }
    public DbSet<BuildWordsGameStatisticModel> BuildWordsGameStatistics { get; set; }


    public async Task<DialogueModel?> GetFullDialogueById(Guid id, CancellationToken cancellationToken)
    {
        return await Dialogues.GetFullDialogueById(id, cancellationToken);
    }

    public async Task<DialogueModel[]?> GetFullDialogues(CancellationToken cancellationToken)
    {
        var dbModel = new DBModels()
        {
            Dialogues = await Dialogues
                .Include(d => d.Phrase)
                .ToArrayAsync(cancellationToken),
            
            AudioSettings = await AudioSettings
                .Select(a => a)
                .ToArrayAsync(),
            
            Answers = await Answers
                .Select(a => a)
                .ToArrayAsync(),

            Phrases = await Phrases
                .Select(p => p)
                .ToArrayAsync(),

            Translates = await Translates
                .Select(a => a)
                .ToArrayAsync()
        };
       
        return await BuildDialogues(dbModel);
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

        studentBuilder
            .HasMany(s => s.VocabularyBlocks)
            .WithOne(vb => vb.Student)
            .HasForeignKey(s => s.StudentId)
            .IsRequired()
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


        // <-- AudioSettingsModel --> 

        var audioSettings = modelBuilder.Entity<AudioSettingsModel>();

        audioSettings
            .HasOne(a => a.ParentPhrase)
            .WithOne(p => p.AudioSettings)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.Cascade);
        ;

        audioSettings.Property(p => p.ParentPhraseId).IsRequired(true);

        // <-- AudioSettingsModel --> 

        // <-- MistakeExplanations -->
        var mistakeExplanationBuilder = modelBuilder.Entity<MistakeExplanationModel>();
        mistakeExplanationBuilder.HasKey(m => m.Id);
        // </- MistakeExplanations -->

        // <-- Translates -->
        var transaleBuilder = modelBuilder.Entity<TranslateModel>();
        transaleBuilder.HasKey(m => m.Id);
        // </- Translates -->

        // </- Words -->
        var wordsBuilder = modelBuilder.Entity<WordModel>();
        wordsBuilder.HasKey(w => w.Id);

        wordsBuilder
            .HasMany(w => w.Translates)
            .WithOne(wt => wt.Word)
            .HasForeignKey(w => w.WordId)
            .IsRequired()
        ;       

        // </- Words -->

        // <-- Answer -->
        var answerBuilder = modelBuilder.Entity<AnswerModel>();
        answerBuilder.HasKey(a => a.Id);

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

        // <-- StudentDialogueStatistic -->
        var studentDialogueStatisticBuilder = modelBuilder.Entity<StudentDialogueStatisticModel>();

        studentDialogueStatisticBuilder.HasKey(s => s.Id);

        studentDialogueStatisticBuilder
            .HasOne(sd => sd.Student)
            .WithMany(s => s.DialoguesStatistic)
            .HasForeignKey(sd => sd.StudentId)
        ;

        // <-- dialogueHistory -->
        var dialogueHistoryBuilders = modelBuilder.Entity<DialogueHistory>();
        dialogueHistoryBuilders.HasKey(s => s.Id);

        dialogueHistoryBuilders
            .HasOne(dh => dh.StudentDialogueStatistic)
            .WithMany(sd => sd.DialogueHistories)
            .HasForeignKey(sd => sd.StudentDialogueStatisticId)
        ;
        // <-- dialogueHistory -->

        // <-- quizlGameModel -->
        var quizleGameBuilders = modelBuilder.Entity<QuizlGameModel>();
        quizleGameBuilders.HasKey(qg => qg.Id);

        // <-- quizlGameModel -->

        var quizlGameStatisticBuilder = modelBuilder.Entity<QuizlGameStatisticModel>();
        quizlGameStatisticBuilder.HasKey(sv => sv.Id);

        quizlGameStatisticBuilder
            .HasOne(qg => qg.VocabularyBlock)
            .WithMany(vb => vb.QuizlGameStatistics)
            .HasForeignKey(qg => qg.VocabularyBlockId)
        ;

        var translateWordsGameStatisticBuilder = modelBuilder.Entity<TranslateWordsGameStatisticModel>();
        translateWordsGameStatisticBuilder.HasKey(sv => sv.Id);

        translateWordsGameStatisticBuilder
            .HasOne(tw => tw.VocabularyBlock)
            .WithMany(vb => vb.TranslateWordsGameStatistics)
            .HasForeignKey(tw => tw.VocabularyBlockId)
        ;

        var buildWordsGameStatisticBuilder = modelBuilder.Entity<BuildWordsGameStatisticModel>();
        buildWordsGameStatisticBuilder.HasKey(sv => sv.Id);

        buildWordsGameStatisticBuilder
            .HasOne(bw => bw.VocabularyBlock)
            .WithMany(vb => vb.BuildWordsGameStatistics)
            .HasForeignKey(bw => bw.VocabularyBlockId)
        ;
    }

    private async Task<DialogueModel[]> BuildDialogues(DBModels dbModel)
    {
        var buildedDialogues = new List<DialogueModel>();

        foreach (var dialogue in dbModel.Dialogues)
        {
            var buildedDialogue = new DialogueModel
            {
                Id = dialogue.Id,
                LevelId = dialogue.LevelId,
                Name = dialogue.Name,
                PhraseId = dialogue.Phrase.Id,
                TeacherId = dialogue.TeacherId,
                IsPublished = dialogue.IsPublished,
                VoiceSettings = dialogue.VoiceSettings,
                Phrase = await RecursiveLoad(dialogue.Phrase, dbModel),
                StudentsId = dialogue.StudentsId,
                VocabularyWordsId = dialogue.VocabularyWordsId,
            };

            buildedDialogues.Add(buildedDialogue);
        }

        return buildedDialogues.ToArray();
    }

    private async Task<PhraseModel> RecursiveLoad(PhraseModel parentPhrase, DBModels dbModel)
    {
        var audioSettings = dbModel.AudioSettings
            .FirstOrDefault(a => a.ParentPhraseId == parentPhrase.Id)
        ;

        var buildedPhrase = new PhraseModel()
        {
            Id = parentPhrase.Id,
            ParentAnswerId = parentPhrase.ParentAnswerId,
            Text = parentPhrase.Text,
            Comments = parentPhrase.Comments,
            Tenseses = parentPhrase.Tenseses,
            AudioSettings = audioSettings
        };

        var answers = dbModel.Answers
            .Where(a => a.ParentPhraseId == parentPhrase.Id)
            .ToArray();
        ;

        foreach (var answer in answers)
        {
            var buildedAnswer = await RecursiveLoad(answer, dbModel);
            buildedPhrase.Answers.Add(buildedAnswer);
        }

        return buildedPhrase;
    }

    private async Task<AnswerModel> RecursiveLoad(AnswerModel parentAnswer, DBModels dbModel)
    {
        var buildedAnswer = new AnswerModel()
        {
            ParentPhraseId = parentAnswer.ParentPhraseId,
            Id = parentAnswer.Id,
            Texts = parentAnswer.Texts,
            Tenseses = parentAnswer.Tenseses,
            WordsToUse = parentAnswer.WordsToUse,
        };

        var translates = dbModel.Translates.Where(t => t.AnswerParentId == parentAnswer.Id).ToArray();

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

        var mistakeExplanations = dbModel.MistakeExplanation
            .Where(m => m.AnswerParentId == parentAnswer.Id)
            .ToArray()
        ;

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

        var phrases = dbModel.Phrases.Where(p => p.ParentAnswerId == parentAnswer.Id).ToArray();
        foreach (var phrase in phrases)
        {
            var buildedPhrase = await RecursiveLoad(phrase, dbModel);
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
        await RemoveStudentDialogueStatistic(dialogue.Id, cancellationToken);

        Dialogues.RemoveRange(dialogue);
    }

    public async Task RemoveStudentDialogueStatistic(Guid dialogueId, CancellationToken cancellationToken) {

        var statistic = StudentDialoguesStatistics.FirstOrDefault(statisctic => statisctic.DialogueId == dialogueId);
        if (statistic == null)
        {
            return;
        }

        StudentDialoguesStatistics.RemoveRange(statistic);
        
        var dialogueHistory = await DialogueHistories.Where(history => history.StudentDialogueStatisticId == statistic.Id ).ToArrayAsync(cancellationToken);
        if (dialogueHistory == null)
        {
            return;
        }
        
        DialogueHistories.RemoveRange(dialogueHistory);
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

        var audioSettings =  AudioSettings
            .AsNoTracking()
            .FirstOrDefault(a => a.ParentPhraseId == phrase.Id)
        ;

        if (audioSettings == null)
        {
            return;
        }

        AudioSettings.RemoveRange(audioSettings);
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

public class DBModels 
{
    public DialogueModel[] Dialogues { get; set; } = [];
    public PhraseModel[] Phrases { get; set; } = [];
    public AnswerModel[] Answers { get; set; } = [];
    public AudioSettingsModel[] AudioSettings { get; set; } = [];
    public TranslateModel[] Translates { get; set; } = [];
    public MistakeExplanationModel[] MistakeExplanation { get; set; } = [];
}