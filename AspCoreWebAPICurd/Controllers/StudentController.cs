using AspCoreWebAPICurd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspCoreWebAPICurd.Controllers
{
    //[Route("api/[controller]")]////
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDbContext db;
        public StudentController(StudentDbContext context)
        {
            this.db = context;
        }

        [HttpGet] // Added missing HTTP method attribute
        [Route("api/Student/GetStudentList")]
        public async Task<IActionResult> GetStudentList()
        {
            var students = await db.Students.ToListAsync(); // Ensure EF Core namespace is included
            return Ok(students);
        }

        [HttpGet] // Added missing HTTP method attribute
        [Route("api/Student/GetStudentById")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await db.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost] // Added missing HTTP method attribute
        [Route("api/Student/CreateStudent")]
        public async Task<IActionResult> CreateStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model state is not valid");
            }
            db.Students.Add(student);
            await db.SaveChangesAsync();
           
           // return CreatedAtAction(nameof(GetStudentById), new { id = student.StdId }, student);
           return Ok(student); // Changed to return Ok for simplicity
        }
        [HttpPut] // Added missing HTTP method attribute
        [Route("api/Student/EditStudent")]
        public async Task<IActionResult> EditStudent(int id, Student student)
        {
            if (id != student.StdId)
            {
                return BadRequest("Student ID mismatch");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Model state is not valid");
            }
            db.Entry(student).State = EntityState.Modified;
            
            await db.SaveChangesAsync();
            return Ok(student);
        }
        [HttpDelete]
        [Route("api/Student/DeleteStudent")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await db.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound("student not exist");
            }
            db.Students.Remove(student);
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}
