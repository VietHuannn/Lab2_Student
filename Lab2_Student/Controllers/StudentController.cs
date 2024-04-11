using Microsoft.AspNetCore.Mvc;
using Lab2_Student.Models;
using Lab2_Student.Services;
namespace Lab2_Student.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly ICoursesServices _coursesService;

        public StudentsController(ICoursesServices coursesService)
        {
            _coursesService = coursesService;
        }

        [HttpGet]
        public async Task<IActionResult> getAllStudent()
        {
            var s = await _coursesService.getAllStudent();

            if (s == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No authors in database");
            }

            return StatusCode(StatusCodes.Status200OK, s);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetStudentsAsync(Guid id, bool includeCourses = false)
        {
            Courses courses = await _coursesService.GetIdCourses(id, includeCourses);

            if (courses == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No Author found for id: {id}");
            }

            return StatusCode(StatusCodes.Status200OK, courses);
        }

        [HttpPost]
        public async Task<ActionResult<Courses>> AddStudentsAsync(Courses courses)
        {
            var dbCourses = await _coursesService.AddCourses(courses);

            if (dbCourses == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{courses.CourseName} could not be added.");
            }

            return CreatedAtAction("GetCourses", new { id = courses.CourseId }, courses);
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateStudentsAsync(Guid id, Courses courses)
        {
            if (id != courses.CourseId)
            {
                return BadRequest();
            }

            Courses dbCourses = await _coursesService.UpdateCourses(courses);

            if (dbCourses == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{courses.CourseName} could not be updated");
            }

            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteStudents(Guid id)
        {
            var courses = await _coursesService.GetIdCourses(id, false);
            (bool status, string message) = await _coursesService.DeleteCourses(courses);

            if (status == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return StatusCode(StatusCodes.Status200OK, courses);
        }
    }
}