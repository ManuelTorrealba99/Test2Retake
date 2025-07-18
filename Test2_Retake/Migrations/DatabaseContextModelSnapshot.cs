﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Test2_Retake.Data;

#nullable disable

namespace Test2_Retake.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Test2_Retake.Models.Backpack", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.HasKey("CharacterId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("Backpack");

                    b.HasData(
                        new
                        {
                            CharacterId = 1,
                            ItemId = 1,
                            Amount = 2
                        },
                        new
                        {
                            CharacterId = 1,
                            ItemId = 2,
                            Amount = 1
                        },
                        new
                        {
                            CharacterId = 1,
                            ItemId = 3,
                            Amount = 1
                        });
                });

            modelBuilder.Entity("Test2_Retake.Models.Character", b =>
                {
                    b.Property<int>("CharacterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CharacterId"));

                    b.Property<int>("CurrentWeight")
                        .HasColumnType("int");

                    b.Property<string>("FisrtName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("MaxWeight")
                        .HasColumnType("int");

                    b.HasKey("CharacterId");

                    b.ToTable("Character");

                    b.HasData(
                        new
                        {
                            CharacterId = 1,
                            CurrentWeight = 43,
                            FisrtName = "John",
                            LastName = "Yakuza",
                            MaxWeight = 200
                        },
                        new
                        {
                            CharacterId = 2,
                            CurrentWeight = 81,
                            FisrtName = "Peter",
                            LastName = "Lewis",
                            MaxWeight = 120
                        },
                        new
                        {
                            CharacterId = 3,
                            CurrentWeight = 11,
                            FisrtName = "Juan",
                            LastName = "Baustista",
                            MaxWeight = 80
                        });
                });

            modelBuilder.Entity("Test2_Retake.Models.CharacterTitle", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("TitleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("AcquiredAt")
                        .HasColumnType("datetime2");

                    b.HasKey("CharacterId", "TitleId");

                    b.HasIndex("TitleId");

                    b.ToTable("CharacterTitle");

                    b.HasData(
                        new
                        {
                            CharacterId = 1,
                            TitleId = 1,
                            AcquiredAt = new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CharacterId = 1,
                            TitleId = 2,
                            AcquiredAt = new DateTime(2024, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CharacterId = 1,
                            TitleId = 3,
                            AcquiredAt = new DateTime(2024, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Test2_Retake.Models.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Weight")
                        .HasMaxLength(100)
                        .HasColumnType("int");

                    b.HasKey("ItemId");

                    b.ToTable("Item");

                    b.HasData(
                        new
                        {
                            ItemId = 1,
                            Name = "Item1",
                            Weight = 10
                        },
                        new
                        {
                            ItemId = 2,
                            Name = "Item2",
                            Weight = 11
                        },
                        new
                        {
                            ItemId = 3,
                            Name = "Item3",
                            Weight = 12
                        });
                });

            modelBuilder.Entity("Test2_Retake.Models.Title", b =>
                {
                    b.Property<int>("TitleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TitleId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("TitleId");

                    b.ToTable("Title");

                    b.HasData(
                        new
                        {
                            TitleId = 1,
                            Name = "Title1"
                        },
                        new
                        {
                            TitleId = 2,
                            Name = "Title2"
                        },
                        new
                        {
                            TitleId = 3,
                            Name = "Title3"
                        });
                });

            modelBuilder.Entity("Test2_Retake.Models.Backpack", b =>
                {
                    b.HasOne("Test2_Retake.Models.Character", "Characters")
                        .WithMany("Backpacks")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Test2_Retake.Models.Item", "Items")
                        .WithMany("Backpacks")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Characters");

                    b.Navigation("Items");
                });

            modelBuilder.Entity("Test2_Retake.Models.CharacterTitle", b =>
                {
                    b.HasOne("Test2_Retake.Models.Character", "Characters")
                        .WithMany("CharacterTitles")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Test2_Retake.Models.Title", "Titles")
                        .WithMany("CharacterTitles")
                        .HasForeignKey("TitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Characters");

                    b.Navigation("Titles");
                });

            modelBuilder.Entity("Test2_Retake.Models.Character", b =>
                {
                    b.Navigation("Backpacks");

                    b.Navigation("CharacterTitles");
                });

            modelBuilder.Entity("Test2_Retake.Models.Item", b =>
                {
                    b.Navigation("Backpacks");
                });

            modelBuilder.Entity("Test2_Retake.Models.Title", b =>
                {
                    b.Navigation("CharacterTitles");
                });
#pragma warning restore 612, 618
        }
    }
}
