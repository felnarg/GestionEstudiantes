using Gestion_Estudiantes.Services;
using Microsoft.AspNetCore.Mvc;
using webapi.Models;

namespace Gestion_Estudiantes.Controllers
{
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        IStudentServices _studentService;

        public StudentController(IStudentServices studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_studentService.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Student student) 
        {
            _studentService.Save(student);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Student student)
        {
            _studentService.Update(id, student);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id) 
        {
            _studentService.Delete(id);
            return Ok();
        }
    }
}
