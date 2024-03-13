﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ThereGame.Infrastructure.Data;

#nullable disable

namespace ThereGame.Infrastructure.Data.Migrations
{
    [DbContext(typeof(ThereGameDbContext))]
    [Migration("20240311194014_InLifeMigrationC")]
    partial class InLifeMigrationC
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AudioSettingsModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AudioData")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("GenerationSettings")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("ParentPhraseId")
                        .IsRequired()
                        .HasColumnType("uuid");

                    b.Property<int>("Revision")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ParentPhraseId")
                        .IsUnique();

                    b.ToTable("AudioSettings");
                });

            modelBuilder.Entity("DialogueHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<List<string>>("Answers")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<string>("Phrase")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("PhraseId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("StudentDialogueStatisticId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("StudentDialogueStatisticId");

                    b.ToTable("DialogueHistories");
                });

            modelBuilder.Entity("StudentDialogueStatisticModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("DialogueId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentDialoguesStatistics");
                });

            modelBuilder.Entity("ThereGame.Business.Domain.Answer.AnswerModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ParentPhraseId")
                        .HasColumnType("uuid");

                    b.Property<string[]>("Tenseses")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string[]>("Texts")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("WordsToUse")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ParentPhraseId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("ThereGame.Business.Domain.Answer.MistakeExplanationModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AnswerParentId")
                        .HasColumnType("uuid");

                    b.Property<string>("Explanation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Word")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AnswerParentId");

                    b.ToTable("MistakeExplanations");
                });

            modelBuilder.Entity("ThereGame.Business.Domain.Dialogue.DialogueModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("boolean");

                    b.Property<Guid>("LevelId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("PhraseId")
                        .HasColumnType("uuid");

                    b.Property<List<Guid>>("StudentsId")
                        .IsRequired()
                        .HasColumnType("uuid[]");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uuid");

                    b.Property<string>("VoiceSettings")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PhraseId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Dialogues");
                });

            modelBuilder.Entity("ThereGame.Business.Domain.Phrase.PhraseModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("ParentAnswerId")
                        .HasColumnType("uuid");

                    b.Property<string[]>("Tenseses")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ParentAnswerId");

                    b.ToTable("Phrases");
                });

            modelBuilder.Entity("ThereGame.Business.Domain.Student.StudentModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("TeacherId")
                        .HasColumnType("uuid");

                    b.Property<Guid[]>("VocabularyIdList")
                        .IsRequired()
                        .HasColumnType("uuid[]");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ThereGame.Business.Domain.Teacher.TeacherModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("ThereGame.Business.Domain.Word.WordModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Word")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Words");
                });

            modelBuilder.Entity("TranslateModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AnswerParentId")
                        .HasColumnType("uuid");

                    b.Property<int>("Language")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AnswerParentId");

                    b.ToTable("Translates");
                });

            modelBuilder.Entity("AudioSettingsModel", b =>
                {
                    b.HasOne("ThereGame.Business.Domain.Phrase.PhraseModel", "ParentPhrase")
                        .WithOne("AudioSettings")
                        .HasForeignKey("AudioSettingsModel", "ParentPhraseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParentPhrase");
                });

            modelBuilder.Entity("DialogueHistory", b =>
                {
                    b.HasOne("StudentDialogueStatisticModel", "StudentDialogueStatistic")
                        .WithMany("DialogueHistories")
                        .HasForeignKey("StudentDialogueStatisticId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StudentDialogueStatistic");
                });

            modelBuilder.Entity("StudentDialogueStatisticModel", b =>
                {
                    b.HasOne("ThereGame.Business.Domain.Student.StudentModel", "Student")
                        .WithMany("DialoguesStatistic")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ThereGame.Business.Domain.Answer.AnswerModel", b =>
                {
                    b.HasOne("ThereGame.Business.Domain.Phrase.PhraseModel", "ParentPhrase")
                        .WithMany("Answers")
                        .HasForeignKey("ParentPhraseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParentPhrase");
                });

            modelBuilder.Entity("ThereGame.Business.Domain.Answer.MistakeExplanationModel", b =>
                {
                    b.HasOne("ThereGame.Business.Domain.Answer.AnswerModel", "Answer")
                        .WithMany("MistakeExplanations")
                        .HasForeignKey("AnswerParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Answer");
                });

            modelBuilder.Entity("ThereGame.Business.Domain.Dialogue.DialogueModel", b =>
                {
                    b.HasOne("ThereGame.Business.Domain.Phrase.PhraseModel", "Phrase")
                        .WithMany("Dialogues")
                        .HasForeignKey("PhraseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThereGame.Business.Domain.Teacher.TeacherModel", "Teacher")
                        .WithMany("Dialogues")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Phrase");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("ThereGame.Business.Domain.Phrase.PhraseModel", b =>
                {
                    b.HasOne("ThereGame.Business.Domain.Answer.AnswerModel", "ParentAnswer")
                        .WithMany("Phrases")
                        .HasForeignKey("ParentAnswerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("ParentAnswer");
                });

            modelBuilder.Entity("ThereGame.Business.Domain.Student.StudentModel", b =>
                {
                    b.HasOne("ThereGame.Business.Domain.Teacher.TeacherModel", "Teacher")
                        .WithMany("Students")
                        .HasForeignKey("TeacherId");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("TranslateModel", b =>
                {
                    b.HasOne("ThereGame.Business.Domain.Answer.AnswerModel", "Answer")
                        .WithMany("Translates")
                        .HasForeignKey("AnswerParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Answer");
                });

            modelBuilder.Entity("StudentDialogueStatisticModel", b =>
                {
                    b.Navigation("DialogueHistories");
                });

            modelBuilder.Entity("ThereGame.Business.Domain.Answer.AnswerModel", b =>
                {
                    b.Navigation("MistakeExplanations");

                    b.Navigation("Phrases");

                    b.Navigation("Translates");
                });

            modelBuilder.Entity("ThereGame.Business.Domain.Phrase.PhraseModel", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("AudioSettings");

                    b.Navigation("Dialogues");
                });

            modelBuilder.Entity("ThereGame.Business.Domain.Student.StudentModel", b =>
                {
                    b.Navigation("DialoguesStatistic");
                });

            modelBuilder.Entity("ThereGame.Business.Domain.Teacher.TeacherModel", b =>
                {
                    b.Navigation("Dialogues");

                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
