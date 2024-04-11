using Microsoft.EntityFrameworkCore;
using Lab2_Student.Models;

namespace Lab2_Student.Data
{ 
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<StudentCourses> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StudentCourses>().HasKey(h => new { h.StudentId, h.CoursesId });
            builder.Entity<StudentCourses>().HasOne(h => h.Courses).WithMany(h => h.StudentCourses);
            builder.Entity<StudentCourses>().HasOne(h => h.Student).WithMany(h => h.StudentCourses);

            new DbInitializer(builder).Seed();
        }


    }
}
