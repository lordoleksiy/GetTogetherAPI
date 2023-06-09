﻿// <auto-generated />
using System;
using GetTogether.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GetTogether.DAL.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GetTogether.DAL.Entities.ChatGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatorId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("ChatGroups");
                });

            modelBuilder.Entity("GetTogether.DAL.Entities.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<int>("ChatId")
                        .HasColumnType("integer");

                    b.Property<int?>("RepliedPersonId")
                        .HasColumnType("integer");

                    b.Property<string>("text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId")
                        .IsUnique();

                    b.HasIndex("ChatId");

                    b.HasIndex("RepliedPersonId")
                        .IsUnique();

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("GetTogether.DAL.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "sherman.net",
                            Login = "Dora.Stamm",
                            Name = "Dora"
                        },
                        new
                        {
                            Id = 2,
                            Description = "sally.info",
                            Login = "Juan.Swift",
                            Name = "Juan"
                        },
                        new
                        {
                            Id = 3,
                            Description = "nyah.biz",
                            Login = "Nellie_Ankunding8",
                            Name = "Nellie"
                        },
                        new
                        {
                            Id = 4,
                            Description = "devin.biz",
                            Login = "Julia.King",
                            Name = "Julia"
                        },
                        new
                        {
                            Id = 5,
                            Description = "lenny.org",
                            Login = "Lewis86",
                            Name = "Lewis"
                        });
                });

            modelBuilder.Entity("object", b =>
                {
                    b.Property<int>("GroupId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("FollowerId")
                        .HasColumnType("integer");

                    b.HasKey("GroupId", "UserId");

                    b.HasIndex("FollowerId");

                    b.HasIndex("UserId");

                    b.ToTable("ChatGroupsUsers", (string)null);
                });

            modelBuilder.Entity("GetTogether.DAL.Entities.ChatGroup", b =>
                {
                    b.HasOne("GetTogether.DAL.Entities.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("GetTogether.DAL.Entities.Message", b =>
                {
                    b.HasOne("GetTogether.DAL.Entities.User", "Author")
                        .WithOne()
                        .HasForeignKey("GetTogether.DAL.Entities.Message", "AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GetTogether.DAL.Entities.ChatGroup", "ChatGroup")
                        .WithMany("Messages")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GetTogether.DAL.Entities.User", "RepliedPerson")
                        .WithOne()
                        .HasForeignKey("GetTogether.DAL.Entities.Message", "RepliedPersonId");

                    b.Navigation("Author");

                    b.Navigation("ChatGroup");

                    b.Navigation("RepliedPerson");
                });

            modelBuilder.Entity("object", b =>
                {
                    b.HasOne("GetTogether.DAL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("FollowerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GetTogether.DAL.Entities.ChatGroup", null)
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GetTogether.DAL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GetTogether.DAL.Entities.ChatGroup", b =>
                {
                    b.Navigation("Messages");
                });
#pragma warning restore 612, 618
        }
    }
}
