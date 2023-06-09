﻿// <auto-generated />
using System;
using GoldenZombiesApiProject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GoldenZombiesApiProject.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230509084804_initialcreation")]
    partial class initialcreation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ModelLibrary.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "Henriks.Mail@Hotmail.com",
                            FirstName = "Henrik",
                            LastName = "Rydén",
                            Title = "Junior"
                        },
                        new
                        {
                            Id = 2,
                            Email = "Kenny.Mail@Hotmail.com",
                            FirstName = "Kenny",
                            LastName = "Lindblom",
                            Title = "Junior"
                        },
                        new
                        {
                            Id = 3,
                            Email = "John.Mail@Hotmail.com",
                            FirstName = "John",
                            LastName = "Albrektsson",
                            Title = "Junior"
                        },
                        new
                        {
                            Id = 4,
                            Email = "Lars.Mail@Hotmail.com",
                            FirstName = "Lars",
                            LastName = "Laxsson",
                            Title = "Senior"
                        },
                        new
                        {
                            Id = 5,
                            Email = "Johanna.Mail@Hotmail.com",
                            FirstName = "Johanna",
                            LastName = "Svensson",
                            Title = "Senior"
                        });
                });

            modelBuilder.Entity("ModelLibrary.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ProjectEnd")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProjectName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ProjectStart")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsActive = true,
                            ProjectEnd = new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProjectName = "BankApplication",
                            ProjectStart = new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            IsActive = true,
                            ProjectEnd = new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProjectName = "ShoppingWebsite",
                            ProjectStart = new DateTime(2021, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            IsActive = true,
                            ProjectEnd = new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProjectName = "Build API",
                            ProjectStart = new DateTime(2022, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            IsActive = false,
                            ProjectName = "Quiz Game",
                            ProjectStart = new DateTime(2022, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            IsActive = true,
                            ProjectEnd = new DateTime(2023, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProjectName = "Desktop Application",
                            ProjectStart = new DateTime(2022, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("ModelLibrary.Models.TimeReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<double>("HoursWorked")
                        .HasColumnType("float");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("WeekNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ProjectId");

                    b.ToTable("TimeReports");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EmployeeId = 1,
                            HoursWorked = 40.200000000000003,
                            ProjectId = 1,
                            WeekNumber = 8
                        },
                        new
                        {
                            Id = 2,
                            EmployeeId = 1,
                            HoursWorked = 10.199999999999999,
                            ProjectId = 2,
                            WeekNumber = 7
                        },
                        new
                        {
                            Id = 3,
                            EmployeeId = 2,
                            HoursWorked = 20.399999999999999,
                            ProjectId = 1,
                            WeekNumber = 8
                        },
                        new
                        {
                            Id = 4,
                            EmployeeId = 2,
                            HoursWorked = 22.300000000000001,
                            ProjectId = 4,
                            WeekNumber = 4
                        },
                        new
                        {
                            Id = 5,
                            EmployeeId = 3,
                            HoursWorked = 20.199999999999999,
                            ProjectId = 4,
                            WeekNumber = 7
                        },
                        new
                        {
                            Id = 6,
                            EmployeeId = 3,
                            HoursWorked = 30.100000000000001,
                            ProjectId = 2,
                            WeekNumber = 6
                        },
                        new
                        {
                            Id = 7,
                            EmployeeId = 4,
                            HoursWorked = 40.200000000000003,
                            ProjectId = 5,
                            WeekNumber = 8
                        },
                        new
                        {
                            Id = 8,
                            EmployeeId = 4,
                            HoursWorked = 30.199999999999999,
                            ProjectId = 4,
                            WeekNumber = 7
                        },
                        new
                        {
                            Id = 9,
                            EmployeeId = 5,
                            HoursWorked = 20.199999999999999,
                            ProjectId = 1,
                            WeekNumber = 4
                        },
                        new
                        {
                            Id = 10,
                            EmployeeId = 5,
                            HoursWorked = 30.100000000000001,
                            ProjectId = 3,
                            WeekNumber = 6
                        });
                });

            modelBuilder.Entity("ModelLibrary.Models.TimeReport", b =>
                {
                    b.HasOne("ModelLibrary.Models.Employee", "Employee")
                        .WithMany("TimeReports")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ModelLibrary.Models.Project", "project")
                        .WithMany("TimeReports")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("project");
                });

            modelBuilder.Entity("ModelLibrary.Models.Employee", b =>
                {
                    b.Navigation("TimeReports");
                });

            modelBuilder.Entity("ModelLibrary.Models.Project", b =>
                {
                    b.Navigation("TimeReports");
                });
#pragma warning restore 612, 618
        }
    }
}
