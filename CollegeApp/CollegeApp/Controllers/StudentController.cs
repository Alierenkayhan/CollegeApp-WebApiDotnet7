using CollegeApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CollegeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Student> GetStudents()
        {
            return CollegeRepository.Students;
        }
        [HttpGet("{id:int}")]
        public Student GetStudentById(int id)
        {
            return CollegeRepository.Students.Where(n=>n.Id == id).FirstOrDefault();
        }
    }
}
