using CollegeApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace CollegeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet("All", Name ="GetAllStudents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            //return CollegeRepository.Students;
            //Ok-200-Success
            return Ok(CollegeRepository.Students);
        }



        [HttpGet("{id:int}", Name = "GetStudentById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Student> GetStudentById(int id)
        {
            if (id <= 0)
            {
                //BadRequest - 400 - Client error
                return BadRequest();
            }
            var student = CollegeRepository.Students.Where(n => n.Id == id).FirstOrDefault();
            if (student == null)
            {
                //404
                return NotFound($"The studednt with id {id} not found");
            }
            return Ok(student);
        }



        [HttpGet("{name:alpha}", Name = "GetStudentsByName")] // [Route("{name}", Name = "GetStudentsByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Student> GetStudentsByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest();
           
            var student = CollegeRepository.Students.Where(n => n.StudentName == name).FirstOrDefault();

            if (student == null)
                return NotFound($"The studednt with name {name} not found");

            return Ok(student);
        }



        [HttpDelete("{id:int:min(1):max(100)}", Name = "GetStudentDelete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<bool> GetStudentDelete(int id)
        {

            if (id <= 0)
                return BadRequest();

            var student = CollegeRepository.Students.Where(n => n.Id == id).FirstOrDefault();

            if (student == null)
                return NotFound($"The studednt with name {id} not found");

            CollegeRepository.Students.Remove(student);
            return Ok(true);
        } 
    }
}
