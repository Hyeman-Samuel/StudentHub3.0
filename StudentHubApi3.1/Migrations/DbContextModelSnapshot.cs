﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentHubApi1;

namespace StudentHubApi1.Migrations
{
    [DbContext(typeof(DbContext))]
    partial class DbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StudentHubApi1.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("StudentHubApi1.Models.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateAdded");

                    b.Property<string>("Description");

                    b.Property<int>("Flags");

                    b.Property<Guid?>("QuestionId");

                    b.Property<Guid?>("SolutionId");

                    b.Property<int>("Upvotes");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("SolutionId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("StudentHubApi1.Models.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ImageLatex");

                    b.Property<string>("ImageLink");

                    b.Property<Guid?>("QuestionId");

                    b.Property<Guid?>("SolutionId");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("SolutionId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("StudentHubApi1.Models.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CategoryId");

                    b.Property<DateTime>("DateAdded");

                    b.Property<string>("Description");

                    b.Property<int>("DownVotes");

                    b.Property<int>("Flags");

                    b.Property<Guid>("ImageId");

                    b.Property<int>("Saves");

                    b.Property<string>("Title");

                    b.Property<int>("UpVotes");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("StudentHubApi1.Models.QuestionTag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("QuestionId");

                    b.Property<Guid>("TagId");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("TagId");

                    b.ToTable("QuestionTag");
                });

            modelBuilder.Entity("StudentHubApi1.Models.Solution", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateAdded");

                    b.Property<string>("Description");

                    b.Property<int>("Flags");

                    b.Property<bool>("IsCorrect");

                    b.Property<Guid>("QuestionId");

                    b.Property<int>("Upvotes");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Solutions");
                });

            modelBuilder.Entity("StudentHubApi1.Models.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("StudentHubApi1.Models.Comment", b =>
                {
                    b.HasOne("StudentHubApi1.Models.Question", "Question")
                        .WithMany("Comments")
                        .HasForeignKey("QuestionId");

                    b.HasOne("StudentHubApi1.Models.Solution", "Solution")
                        .WithMany("Comments")
                        .HasForeignKey("SolutionId");
                });

            modelBuilder.Entity("StudentHubApi1.Models.Image", b =>
                {
                    b.HasOne("StudentHubApi1.Models.Question", "Question")
                        .WithMany("Image")
                        .HasForeignKey("QuestionId");

                    b.HasOne("StudentHubApi1.Models.Solution", "Solution")
                        .WithMany("Images")
                        .HasForeignKey("SolutionId");
                });

            modelBuilder.Entity("StudentHubApi1.Models.Question", b =>
                {
                    b.HasOne("StudentHubApi1.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StudentHubApi1.Models.QuestionTag", b =>
                {
                    b.HasOne("StudentHubApi1.Models.Question", "Question")
                        .WithMany("Tags")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StudentHubApi1.Models.Tag", "Tag")
                        .WithMany("QuestionTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StudentHubApi1.Models.Solution", b =>
                {
                    b.HasOne("StudentHubApi1.Models.Question", "Question")
                        .WithMany("Solutions")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
