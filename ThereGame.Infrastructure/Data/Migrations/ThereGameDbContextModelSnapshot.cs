﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ThereGame.Infrastructure.Data;

#nullable disable

namespace ThereGame.Infrastructure.Data.Migrations
{
    [DbContext(typeof(ThereGameDbContext))]
    partial class ThereGameDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

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

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

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

                    b.Property<bool>("IsVoiceSelected")
                        .HasColumnType("boolean");

                    b.Property<Guid>("LevelId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("PhraseId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PhraseId");

                    b.HasIndex("UserId");

                    b.ToTable("Dialogues");
                });

            modelBuilder.Entity("ThereGame.Business.Domain.Phrase.PhraseModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AudioData")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AudioGenerationSettings")
                        .IsRequired()
                        .HasColumnType("text");

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

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ThereGame.Business.Domain.User.UserModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

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

                    b.ToTable("Users");
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

                    b.HasOne("ThereGame.Business.Domain.User.UserModel", "User")
                        .WithMany("Dialogues")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Phrase");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ThereGame.Business.Domain.Phrase.PhraseModel", b =>
                {
                    b.HasOne("ThereGame.Business.Domain.Answer.AnswerModel", "ParentAnswer")
                        .WithMany("Phrases")
                        .HasForeignKey("ParentAnswerId");

                    b.Navigation("ParentAnswer");
                });

            modelBuilder.Entity("ThereGame.Business.Domain.Student.StudentModel", b =>
                {
                    b.HasOne("ThereGame.Business.Domain.User.UserModel", "Teacher")
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

            modelBuilder.Entity("ThereGame.Business.Domain.Answer.AnswerModel", b =>
                {
                    b.Navigation("MistakeExplanations");

                    b.Navigation("Phrases");

                    b.Navigation("Translates");
                });

            modelBuilder.Entity("ThereGame.Business.Domain.Phrase.PhraseModel", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("Dialogues");
                });

            modelBuilder.Entity("ThereGame.Business.Domain.User.UserModel", b =>
                {
                    b.Navigation("Dialogues");

                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
