using Microsoft.EntityFrameworkCore;
using Lab2_Student.Data;
using Lab2_Student.Models;

namespace Lab2_Student.Services
{
    public class CoursesServices : ICoursesServices
    {
        private readonly AppDbContext _db;
        private ICoursesServices _coursesServicesImplementation;
        public CoursesServices(AppDbContext context) { _db = context; }

        #region Courses

        public async Task<List<Courses>> GetAllCourses()
        {
            try
            {
                return await _db.Courses.ToListAsync();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Courses> GetIdCourses(Guid id, bool includeCourses)
        {
            try
            {
                if (includeCourses)
                {
                    return await _db.Courses.Include(c => c.StudentCourses).FirstOrDefaultAsync(i => i.CourseId == id);
                }

                return await _db.Courses.FindAsync(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Courses> AddCourses(Courses courses)
        {
            try
            {
                await _db.Courses.AddAsync(courses);
                await _db.SaveChangesAsync();
                return await _db.Courses.FindAsync(courses.CourseId);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Courses> UpdateCourses(Courses courses)
        {
            try
            {
                _db.Entry(courses).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                return courses;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<(bool, string)> DeleteCourses(Courses courses)
        {
            try
            {
                var dbCourses = await _db.Courses.FindAsync(courses.CourseId);
                if (dbCourses == null)
                {
                    return (false, "Not Found");
                }

                _db.Courses.Remove(courses);
                return (true, "Success");
            }
            catch (Exception e)
            {
                return (false, "Failed");
            }
        }
        #endregion


        #region Students

        public async Task<List<Student>> getAllStudent()
        {
            try
            {
                return await _db.Students.ToListAsync();
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public async Task<Student> GetStudentsAsync(Guid id, bool includeCourses)
        {
            try
            {
                if (includeCourses)
                {
                    return await _db.Students.Include(c => c.StudentCourses).FirstOrDefaultAsync(i => i.StudentId == id);
                }

                return await _db.Students.FindAsync(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public async Task<Student> AddStudentsAsync(Student student)
        {
            try
            {
                await _db.Students.AddAsync(student);
                await _db.SaveChangesAsync();
                return await _db.Students.FindAsync(student.StudentId); // Auto ID from DB
            }
            catch (Exception ex)
            {
                return null; // An error occured
            }
        }

        public async Task<Student> UpdateStudentsAsync(Student student)
        {
            try
            {
                _db.Entry(student).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                return student;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<(bool, string)> DeleteStudentsAsync(Student student)
        {
            try
            {
                var dbstudents = await _db.Students.FindAsync(student.StudentId);

                if (dbstudents == null)
                {
                    return (false, "Student could not be found.");
                }

                _db.Students.Remove(student);
                await _db.SaveChangesAsync();

                return (true, "Student got deleted.");
            }
            catch (Exception ex)
            {
                return (false, $"An error occured. Error Message: {ex.Message}");
            }
        }
        #endregion

        #region StudentCourses
        public async Task<List<StudentCourses>> GetAllsc()
        {
            try
            {
                return await _db.StudentCourses.ToListAsync();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<StudentCourses> GetIdsc(Guid id)
        {
            try
            {
                return await _db.StudentCourses.FindAsync(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<StudentCourses> Addsc(StudentCourses sc)
        {
            try
            {
                await _db.StudentCourses.AddAsync(sc);
                await _db.SaveChangesAsync();

                return await _db.StudentCourses.FindAsync(sc.CoursesId);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<StudentCourses> Updatesc(StudentCourses sc)
        {
            try
            {
                _db.Entry(sc).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                return sc;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<(bool, string)> Deletesc(StudentCourses sc)
        {
            try
            {
                var dbSC = await _db.StudentCourses.FindAsync(sc.CoursesId);
                if (dbSC == null)
                {
                    return (false, "Courses could not be found");
                }
                _db.StudentCourses.Remove(sc);
                await _db.SaveChangesAsync();
                return (true, "Amazing good job you");
            }
            catch (Exception e)
            {
                return (false, e.Message);
            }
        }
        #endregion
    }
}