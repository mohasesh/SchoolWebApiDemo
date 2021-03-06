﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolWebApiDemo.Data;

namespace SchoolWebApiDemo.Migrations
{
    [DbContext(typeof(SchoolContext))]
    partial class SchoolContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SchoolWebApiDemo.Models.Course", b =>
                {
                    b.Property<string>("CourseCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CourseTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CreditHour")
                        .HasColumnType("int");

                    b.HasKey("CourseCode");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("SchoolWebApiDemo.Models.Enrollement", b =>
                {
                    b.Property<int>("EnrollId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseCode1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EnrollId");

                    b.HasIndex("CourseCode1");

                    b.HasIndex("StudentId");

                    b.ToTable("Enroll");
                });

            modelBuilder.Entity("SchoolWebApiDemo.Models.Student", b =>
                {
                    b.Property<Guid>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("SchoolWebApiDemo.Models.Enrollement", b =>
                {
                    b.HasOne("SchoolWebApiDemo.Models.Course", "Course")
                        .WithMany("Enroll")
                        .HasForeignKey("CourseCode1");

                    b.HasOne("SchoolWebApiDemo.Models.Student", "Student")
                        .WithMany("Enroll")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SchoolWebApiDemo.Models.Course", b =>
                {
                    b.Navigation("Enroll");
                });

            modelBuilder.Entity("SchoolWebApiDemo.Models.Student", b =>
                {
                    b.Navigation("Enroll");
                });
#pragma warning restore 612, 618
        }
    }
}
