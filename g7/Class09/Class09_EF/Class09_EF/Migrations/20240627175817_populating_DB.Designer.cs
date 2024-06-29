﻿// <auto-generated />
using System;
using Class09_EF.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Class09_EF.Migrations
{
    [DbContext(typeof(StudentDbContext))]
    [Migration("20240627175817_populating_DB")]
    partial class populating_DB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Class09_EF.Models.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfClasses")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "C# basic",
                            NumberOfClasses = 40
                        },
                        new
                        {
                            Id = 2,
                            Name = "C# advanced",
                            NumberOfClasses = 60
                        },
                        new
                        {
                            Id = 3,
                            Name = "Database development and design",
                            NumberOfClasses = 28
                        },
                        new
                        {
                            Id = 4,
                            Name = "ASP.NET MVC",
                            NumberOfClasses = 40
                        });
                });

            modelBuilder.Entity("Class09_EF.Models.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ActiveCourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ActiveCourseId = 4,
                            DateOfBirth = new DateTime(1999, 6, 27, 19, 58, 17, 157, DateTimeKind.Local).AddTicks(4978),
                            FirstName = "Bob",
                            LastName = "Bobski"
                        },
                        new
                        {
                            Id = 2,
                            ActiveCourseId = 3,
                            DateOfBirth = new DateTime(2001, 6, 27, 19, 58, 17, 157, DateTimeKind.Local).AddTicks(5021),
                            FirstName = "John",
                            LastName = "Doe"
                        },
                        new
                        {
                            Id = 3,
                            ActiveCourseId = 2,
                            DateOfBirth = new DateTime(2006, 6, 27, 19, 58, 17, 157, DateTimeKind.Local).AddTicks(5027),
                            FirstName = "Todor",
                            LastName = "Pelivanov"
                        },
                        new
                        {
                            Id = 4,
                            ActiveCourseId = 1,
                            DateOfBirth = new DateTime(2000, 6, 27, 19, 58, 17, 157, DateTimeKind.Local).AddTicks(5030),
                            FirstName = "Ivan",
                            LastName = "Popovski"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
