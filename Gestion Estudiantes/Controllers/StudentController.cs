using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Application.Interfaces;

namespace Gestion_Estudiantes.Controllers
{
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentServices _studentService;
        private readonly IDailyClass _dailyClass;

        public StudentController(IStudentServices studentService, IDailyClass dailyClass)
        {
            _studentService = studentService;
            _dailyClass = dailyClass;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_studentService.Get());
        }
        [HttpGet("studentid/{id}")]
        public IActionResult GetStudentIdFilter(Guid id)
        {
            return Ok(_studentService.StudentIdFilter(id));
        }
        [HttpGet("studentage/{condition}")]
        public IActionResult GetStudentAgeContiditions(string condition)
        {
            return Ok(_studentService.GetStudentAgeContiditions(condition));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Student student) 
        {
            if (student.Name == null|| student.Name =="")
                return BadRequest("La propiedad nombre no puede ser nula o vacia");

            _studentService.Save(student);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Student student)
        {
            if (student.Name == null || student.Name == "")
                return BadRequest("La propiedad nombre no puede ser nula o vacia");
            _studentService.Update(id, student);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id) 
        {
            _studentService.Delete(id);
            return Ok();
        }

        [HttpGet("dailymorning/{id}")]
        public IActionResult GetDaily(Guid id)
        {
            return Ok(_dailyClass.GetDailyClass(id));
        }
    }
}
