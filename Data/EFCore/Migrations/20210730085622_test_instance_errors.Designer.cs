﻿// <auto-generated />
using System;
using Data.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.EFCore.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210730085622_test_instance_errors")]
    partial class test_instance_errors
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("Core.Entities.Branch", b =>
                {
                    b.Property<string>("Bank")
                        .HasColumnType("TEXT");

                    b.Property<string>("OU")
                        .HasColumnType("TEXT");

                    b.Property<string>("Info")
                        .HasColumnType("TEXT");

                    b.HasKey("Bank", "OU");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("Core.Entities.Check", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("HasNotRelevantOption")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Help")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Checks");
                });

            modelBuilder.Entity("Core.Entities.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Core.Entities.Test", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("Core.Entities.TestCheck", b =>
                {
                    b.Property<Guid>("TestId")
                        .HasColumnType("TEXT");

                    b.Property<int>("CheckId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("INTEGER");

                    b.HasKey("TestId", "CheckId");

                    b.HasIndex("CheckId");

                    b.ToTable("TestChecks");
                });

            modelBuilder.Entity("Core.Entities.TestCheckResponse", b =>
                {
                    b.Property<Guid>("TestId")
                        .HasColumnType("TEXT");

                    b.Property<string>("WorkstationName")
                        .HasColumnType("TEXT");

                    b.Property<int>("CheckId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Value")
                        .HasColumnType("INTEGER");

                    b.HasKey("TestId", "WorkstationName", "CheckId");

                    b.HasIndex("TestId", "CheckId");

                    b.ToTable("TestCheckResponses");
                });

            modelBuilder.Entity("Core.Entities.TestInstance", b =>
                {
                    b.Property<Guid>("TestId")
                        .HasColumnType("TEXT");

                    b.Property<string>("WorkstationName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Completed")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Damaged")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GroupId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LastUpdateTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("NegativeResponses")
                        .HasColumnType("INTEGER");

                    b.HasKey("TestId", "WorkstationName");

                    b.HasIndex("GroupId");

                    b.HasIndex("WorkstationName");

                    b.ToTable("TestInstances");
                });

            modelBuilder.Entity("Core.Entities.TestInstanceNote", b =>
                {
                    b.Property<Guid>("TestId")
                        .HasColumnType("TEXT");

                    b.Property<string>("WorkstationName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TestId", "WorkstationName", "CreationTime");

                    b.ToTable("TestInstanceNotes");
                });

            modelBuilder.Entity("Core.Entities.Workstation", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Bank")
                        .HasColumnType("TEXT");

                    b.Property<string>("OU")
                        .HasColumnType("TEXT");

                    b.HasKey("Name");

                    b.HasIndex("Bank", "OU");

                    b.ToTable("Workstations");
                });

            modelBuilder.Entity("Core.Entities.TestCheck", b =>
                {
                    b.HasOne("Core.Entities.Check", "Check")
                        .WithMany("TestChecks")
                        .HasForeignKey("CheckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Test", "Test")
                        .WithMany("TestChecks")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Check");

                    b.Navigation("Test");
                });

            modelBuilder.Entity("Core.Entities.TestCheckResponse", b =>
                {
                    b.HasOne("Core.Entities.TestCheck", "TestCheck")
                        .WithMany("Responses")
                        .HasForeignKey("TestId", "CheckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TestInstance", "TestInstance")
                        .WithMany("Responses")
                        .HasForeignKey("TestId", "WorkstationName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TestCheck");

                    b.Navigation("TestInstance");
                });

            modelBuilder.Entity("Core.Entities.TestInstance", b =>
                {
                    b.HasOne("Core.Entities.Group", "Group")
                        .WithMany("TestInstances")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Core.Entities.Test", "Test")
                        .WithMany("Instances")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Workstation", "Workstation")
                        .WithMany("TestInstances")
                        .HasForeignKey("WorkstationName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Test");

                    b.Navigation("Workstation");
                });

            modelBuilder.Entity("Core.Entities.TestInstanceNote", b =>
                {
                    b.HasOne("Core.Entities.TestInstance", "TestInstance")
                        .WithMany("Notes")
                        .HasForeignKey("TestId", "WorkstationName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TestInstance");
                });

            modelBuilder.Entity("Core.Entities.Workstation", b =>
                {
                    b.HasOne("Core.Entities.Branch", "Branch")
                        .WithMany("Workstations")
                        .HasForeignKey("Bank", "OU")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Branch");
                });

            modelBuilder.Entity("Core.Entities.Branch", b =>
                {
                    b.Navigation("Workstations");
                });

            modelBuilder.Entity("Core.Entities.Check", b =>
                {
                    b.Navigation("TestChecks");
                });

            modelBuilder.Entity("Core.Entities.Group", b =>
                {
                    b.Navigation("TestInstances");
                });

            modelBuilder.Entity("Core.Entities.Test", b =>
                {
                    b.Navigation("Instances");

                    b.Navigation("TestChecks");
                });

            modelBuilder.Entity("Core.Entities.TestCheck", b =>
                {
                    b.Navigation("Responses");
                });

            modelBuilder.Entity("Core.Entities.TestInstance", b =>
                {
                    b.Navigation("Notes");

                    b.Navigation("Responses");
                });

            modelBuilder.Entity("Core.Entities.Workstation", b =>
                {
                    b.Navigation("TestInstances");
                });
#pragma warning restore 612, 618
        }
    }
}
