using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CoolApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoolApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private StudentContext _studentContext { get; set; }

        public StudentsController(StudentContext ctx)
        {
            _studentContext = ctx;
        }

        // GET api/student
        [HttpGet]
        public ActionResult<IEnumerable<Student>> Get()
        {
            return _studentContext.Students.ToList();
        }

        [HttpGet]
        [Route("getbyid/{id}")]
        public ActionResult<Student> GetById(int id)
        {
            if(id <= 0) 
            {
                return NotFound("Student id must be higher than zero");
            }

            Student student = _studentContext.Students.FirstOrDefault(s => s.StudentId == id);
            
            if(student == null)
            {
                return NotFound("Student not found");
            }

            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]Student student)
        {
            if(student == null)
            {
                return NotFound("Student data is not supplied");
            }

            if(!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            await _studentContext.Students.AddAsync(student);
            await _studentContext.SaveChangesAsync();

            return Ok(student);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody]Student student)
        {
            if(student == null)
            {
                return NotFound("Student data is not supplied");
            }

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Student existingStudent = _studentContext.Students.FirstOrDefault(s => s.StudentId == student.StudentId);
            
            if(existingStudent == null)
            {
                return NotFound("Student does not exist in the database");
            }

            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;
            existingStudent.City = student.City;
            existingStudent.State = student.State;

            _studentContext.Attach(existingStudent).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _studentContext.SaveChangesAsync();

            return Ok(existingStudent);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Nullable<int> id)
        {
            if(id == null)
            {
                return NotFound("Student Id is not supplied");
            }

            Student student = _studentContext.Students.FirstOrDefault(s => s.StudentId == id);

            if(student == null) {
                return NotFound("Student not found");
            }

            _studentContext.Students.Remove(student);
            await _studentContext.SaveChangesAsync();

            return Ok("Student deleted successfully");
        }

        ~StudentsController()
        {
            _studentContext.Dispose();
        }
    }
}