using System.ComponentModel.DataAnnotations;

namespace Lab2_Student.Models
{
    public class Student
    {
        [Key]
        public Guid? StudentId { get; set; }
        public string? Name { get; set; }
        public List<StudentCourses>? StudentCourses { get; set; }
    }
}