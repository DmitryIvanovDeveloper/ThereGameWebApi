﻿// <auto-generated />
using System;
using Inspirer.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ThereGameWebAPI.ThereGame.Infrastructure.Data.Migrations
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

                    b.Property<string[]>("Tenses")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string[]>("WordsToUse")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.HasKey("Id");

                    b.HasIndex("ParentPhraseId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("ThereGame.Business.Domain.Answer.MistakeExplanationModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AnswerId")
                        .HasColumnType("uuid");

                    b.Property<string>("Explanation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.ToTable("MistakeExplanationModel");
                });

            modelBuilder.Entity("ThereGame.Business.Domain.Dialogue.DialogueModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("PhraseId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PhraseId");

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

                    b.Property<Guid>("ParentAnswerId")
                        .HasColumnType("uuid");

                    b.Property<string[]>("Tenses")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ParentAnswerId");

                    b.ToTable("Phrases");
                });

            modelBuilder.Entity("TranslateModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AnswerId")
                        .HasColumnType("uuid");

                    b.Property<int>("Language")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.ToTable("TranslateModel");
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
                        .HasForeignKey("AnswerId")
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

                    b.Navigation("Phrase");
                });

            modelBuilder.Entity("ThereGame.Business.Domain.Phrase.PhraseModel", b =>
                {
                    b.HasOne("ThereGame.Business.Domain.Answer.AnswerModel", "ParentAnswer")
                        .WithMany("Phrases")
                        .HasForeignKey("ParentAnswerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParentAnswer");
                });

            modelBuilder.Entity("TranslateModel", b =>
                {
                    b.HasOne("ThereGame.Business.Domain.Answer.AnswerModel", "Answer")
                        .WithMany("Translates")
                        .HasForeignKey("AnswerId")
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
#pragma warning restore 612, 618
        }
    }
}
