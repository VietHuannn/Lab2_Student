using Lab2_Student.Models;
namespace Lab2_Student.Services
{
    public interface ICoursesServices
    {
        // Khoa Hoc
        Task<List<Courses>> GetAllCourses();
        Task<Courses> GetIdCourses(Guid id, bool includeCourses = false);
        Task<Courses> AddCourses(Courses courses);
        Task<Courses> UpdateCourses(Courses courses);
        Task<(bool, string)> DeleteCourses(Courses courses);

        // Học Sinh
        Task<List<Student>> getAllStudent(); // GET All Authors
        Task<Student> GetStudentsAsync(Guid id, bool includeBooks = false); // GET Single Author
        Task<Student> AddStudentsAsync(Student student); // POST New Author
        Task<Student> UpdateStudentsAsync(Student student); // PUT Author
        Task<(bool, string)> DeleteStudentsAsync(Student student); // DELETE Author

        //Đăng Ký
        Task<List<StudentCourses>> GetAllsc();
        Task<StudentCourses> GetIdsc(Guid id);
        Task<StudentCourses> Addsc(StudentCourses sc);
        Task<StudentCourses> Updatesc(StudentCourses sc);
        Task<(bool, string)> Deletesc(StudentCourses sc);
    }
}