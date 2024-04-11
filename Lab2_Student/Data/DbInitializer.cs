using Microsoft.EntityFrameworkCore;
using Lab2_Student.Models;

namespace Lab2_Student.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder _builder;
        public DbInitializer(ModelBuilder builder)
        {
            this._builder = builder;
        }

        public void Seed()
        {
            _builder.Entity<Student>(s =>
            {
                s.HasData(new Student
                {
                    StudentId = new Guid("e2397972-8743-431a-9482-60292f08450a"),
                    Name = "Le Viet Huan"
                });
                s.HasData(new Student
                {
                    StudentId = new Guid("4e79044a-988d-4488-97b7-3e474e4890a9"),
                    Name = "Nguyen Thi Nhi"
                });
            });
            _builder.Entity<Courses>(c =>
            {
                c.HasData(new Courses
                {
                    CourseId = new Guid("9250d994-2558-4573-8465-417248667562"),
                    CourseName = "CSDL",
                    Description = "So do ERD"
                });
                c.HasData(new Courses
                {
                    CourseId = new Guid("88738493-3a85-4443-8f6a-313453432988"),
                    CourseName = "Phim",
                    Description = "Phim that chill",
                });
            });
            _builder.Entity<StudentCourses>(sc =>
            {
                sc.HasData(new StudentCourses
                {
                    StudentId = new Guid("e2397972-8743-431a-9482-60292f08450a"),
                    CoursesId = new Guid("88738493-3a85-4443-8f6a-313453432988")
                });
                sc.HasData(new StudentCourses
                {
                    StudentId = new Guid("4e79044a-988d-4488-97b7-3e474e4890a9"),
                    CoursesId = new Guid("9250d994-2558-4573-8465-417248667562")
                });
            });

        }
    }
}