using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudenAPI.Context;
using StudenAPI.Models;

namespace StudenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        ApplicationDbContext context;

        public StudentController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var students = context.Students.ToList();
            if (students.Count == 0)
            {
                return NotFound();
            }
            return Ok(new { data = students, msg = "Students retrieved successfully" });
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetByID(int id)
        {
            var student = context.Students.FirstOrDefault(s => s.Ssn == id);

            if (student == null)
            {
                return NotFound();
            }
            return Ok(new { data = student, msg = $"{student.Name} retrieved successfully" });

        }

        [HttpGet]
        [Route("{name:alpha}")]
        public IActionResult GetByName(string name)
        {
            var student = context.Students.FirstOrDefault(s => s.Name == name);

            if (student == null)
            {
                return NotFound();
            }
            return Ok(new { data = student, msg = $"{student.Name} retrieved successfully" });
        }

        [HttpPost]
        public IActionResult Add(Student student)
        {
            if (student == null)
            {
                return BadRequest();
            }
            context.Students.Add(student);
            context.SaveChanges();
            return Ok(new { data = student, msg = $"{student.Name} added successfully" });
        }

        [HttpPut]
        public IActionResult Update(Student student)
        {
            if (student == null)
            {
                return BadRequest();
            }
            context.Students.Update(student);
            context.SaveChanges();
            return Ok(new { data = student, msg = $"{student.Name} Updated successfully" });
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            var student = context.Students.FirstOrDefault(s => s.Ssn == id);
            if (student == null)
            {
                return NotFound();
            }
            context.Students.Remove(student);
            context.SaveChanges();
            return Ok(new { data = student, msg = $"{student.Name} Deleted successfully" });
        }
    }
}
