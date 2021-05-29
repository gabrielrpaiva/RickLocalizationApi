﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RickLocalization.Repository.Context;

namespace RickLocalization.Repository.Migrations
{
    [DbContext(typeof(RickLocalizationContext))]
    [Migration("20210529142553_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RickLocalization.Domain.Entities.DimensionsEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("NAME");

                    b.HasKey("Id");

                    b.ToTable("TBL_DIMENSIONS");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "CRONENBERG C-137"
                        },
                        new
                        {
                            Id = 2,
                            Name = "WASTELAND"
                        },
                        new
                        {
                            Id = 3,
                            Name = "DOG"
                        },
                        new
                        {
                            Id = 4,
                            Name = "TOILET"
                        },
                        new
                        {
                            Id = 5,
                            Name = "FURNITURE/PIZZA/PHONE WORLDS"
                        },
                        new
                        {
                            Id = 6,
                            Name = "NEW CRONENBERG WORLD"
                        },
                        new
                        {
                            Id = 7,
                            Name = "FROOPYLAND"
                        },
                        new
                        {
                            Id = 8,
                            Name = "TESTICLE MONSTER WORLD"
                        },
                        new
                        {
                            Id = 9,
                            Name = "GREASY GRANDMA WORLD"
                        },
                        new
                        {
                            Id = 10,
                            Name = "HAMSTER-IN-BUTT WORLD"
                        });
                });

            modelBuilder.Entity("RickLocalization.Domain.Entities.HumansByDimensionsEntity", b =>
                {
                    b.Property<int>("IdHuman")
                        .HasColumnType("int")
                        .HasColumnName("ID_HUMAN");

                    b.Property<int>("IdDimension")
                        .HasColumnType("int")
                        .HasColumnName("ID_DIMENSION");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("IdHumanResponsibleForMe")
                        .HasColumnType("int")
                        .HasColumnName("ID_HUMAN_RESPONSIBLE_FOR_ME");

                    b.Property<int?>("IdResponsibleForWhichHuman")
                        .HasColumnType("int")
                        .HasColumnName("ID_RESPONSIBLE_FOR_WHICH_HUMAN");

                    b.HasKey("IdHuman", "IdDimension");

                    b.HasIndex("IdDimension");

                    b.HasIndex("IdHumanResponsibleForMe");

                    b.HasIndex("IdResponsibleForWhichHuman");

                    b.ToTable("TBL_HUMANS_BY_DIMENSIONS");

                    b.HasData(
                        new
                        {
                            IdHuman = 1,
                            IdDimension = 1,
                            Id = 1,
                            IdResponsibleForWhichHuman = 2
                        },
                        new
                        {
                            IdHuman = 2,
                            IdDimension = 1,
                            Id = 1,
                            IdHumanResponsibleForMe = 1
                        });
                });

            modelBuilder.Entity("RickLocalization.Domain.Entities.HumansEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("NAME");

                    b.HasKey("Id");

                    b.ToTable("TBL_HUMANS");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Rick Sanchez"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Morty"
                        });
                });

            modelBuilder.Entity("RickLocalization.Domain.Entities.TravelHistoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DimensionsId")
                        .HasColumnType("int");

                    b.Property<int?>("HumansByDimensionsIdDimension")
                        .HasColumnType("int");

                    b.Property<int?>("HumansByDimensionsIdHuman")
                        .HasColumnType("int");

                    b.Property<int>("IdHumansByDimensions")
                        .HasColumnType("int");

                    b.Property<int>("IdTargetDimension")
                        .HasColumnType("int")
                        .HasColumnName("ID_TARGET_DIMENSION");

                    b.Property<DateTime>("TravelDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("TRAVEL_DATE");

                    b.HasKey("Id");

                    b.HasIndex("DimensionsId");

                    b.HasIndex("HumansByDimensionsIdHuman", "HumansByDimensionsIdDimension");

                    b.ToTable("TBL_TRAVEL_HISTORY");
                });

            modelBuilder.Entity("RickLocalization.Domain.Entities.HumansByDimensionsEntity", b =>
                {
                    b.HasOne("RickLocalization.Domain.Entities.DimensionsEntity", "Dimensions")
                        .WithMany()
                        .HasForeignKey("IdDimension")
                        .HasConstraintName("FK_HUMANS_BY_DIMENSIONS_DIMENSIONS")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RickLocalization.Domain.Entities.HumansEntity", "Human")
                        .WithMany()
                        .HasForeignKey("IdHuman")
                        .HasConstraintName("FK_HUMANS_BY_DIMENSIONS_HUMAN")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RickLocalization.Domain.Entities.HumansEntity", "HumanResponsibleForMe")
                        .WithMany()
                        .HasForeignKey("IdHumanResponsibleForMe")
                        .HasConstraintName("FK_HUMANS_BY_DIMENSIONS_HUMAN_RESPONSIBLE_FOR_ME")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("RickLocalization.Domain.Entities.HumansEntity", "ResponsibleForWhichHuman")
                        .WithMany()
                        .HasForeignKey("IdResponsibleForWhichHuman")
                        .HasConstraintName("FK_HUMANS_BY_DIMENSIONS_RESPONSIBLE_FOR_WHICH_HUMAN")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Dimensions");

                    b.Navigation("Human");

                    b.Navigation("HumanResponsibleForMe");

                    b.Navigation("ResponsibleForWhichHuman");
                });

            modelBuilder.Entity("RickLocalization.Domain.Entities.TravelHistoryEntity", b =>
                {
                    b.HasOne("RickLocalization.Domain.Entities.DimensionsEntity", "Dimensions")
                        .WithMany()
                        .HasForeignKey("DimensionsId");

                    b.HasOne("RickLocalization.Domain.Entities.HumansByDimensionsEntity", "HumansByDimensions")
                        .WithMany("TravelHistories")
                        .HasForeignKey("HumansByDimensionsIdHuman", "HumansByDimensionsIdDimension");

                    b.Navigation("Dimensions");

                    b.Navigation("HumansByDimensions");
                });

            modelBuilder.Entity("RickLocalization.Domain.Entities.HumansByDimensionsEntity", b =>
                {
                    b.Navigation("TravelHistories");
                });
#pragma warning restore 612, 618
        }
    }
}
