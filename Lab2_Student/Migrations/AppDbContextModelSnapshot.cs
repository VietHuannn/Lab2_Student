﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Lab2_Student.Data;

#nullable disable

namespace Lab2_Student.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Lab2_Student.Controllers.Courses", b =>
                {
                    b.Property<Guid?>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CourseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CourseId = new Guid("9250d994-2558-4573-8465-417248667051"),
                            CourseName = "CSDL",
                            Description = "So do ERD"
                        },
                        new
                        {
                            CourseId = new Guid("88738493-3a85-4443-8f6a-313453432192"),
                            CourseName = "Phim",
                            Description = "Phim that chill"
                        });
                });

            modelBuilder.Entity("Lab2_Student.Controllers.Student", b =>
                {
                    b.Property<Guid?>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentId = new Guid("e2397972-8743-431a-9482-60292f08320e"),
                            Name = "Le Viet Huan"
                        },
                        new
                        {
                            StudentId = new Guid("4e79044a-988d-4488-97b7-3e474e4340d2"),
                            Name = "Nguyen Thi Nhi"
                        });
                });

            modelBuilder.Entity("Lab2_Student.Controllers.StudentCourses", b =>
                {
                    b.Property<Guid?>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CoursesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("StudentId", "CoursesId");

                    b.HasIndex("CoursesId");

                    b.ToTable("StudentCourses");

                    b.HasData(
                        new
                        {
                            StudentId = new Guid("e2397972-8743-431a-9482-60292f08320e"),
                            CoursesId = new Guid("88738493-3a85-4443-8f6a-313453432192")
                        },
                        new
                        {
                            StudentId = new Guid("4e79044a-988d-4488-97b7-3e474e4340d2"),
                            CoursesId = new Guid("9250d994-2558-4573-8465-417248667051")
                        });
                });

            modelBuilder.Entity("Lab2_Student.Controllers.StudentCourses", b =>
                {
                    b.HasOne("Lab2_Student.Controllers.Courses", "Courses")
                        .WithMany("StudentCourses")
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab2_Student.Controllers.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Courses");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Lab2_Student.Controllers.Courses", b =>
                {
                    b.Navigation("StudentCourses");
                });

            modelBuilder.Entity("Lab2_Student.Controllers.Student", b =>
                {
                    b.Navigation("StudentCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
