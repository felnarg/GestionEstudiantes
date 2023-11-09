using Microsoft.AspNetCore.Mvc;
using Domain.Models;

namespace Gestion_Estudiantes.Controllers
{
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        ICourseServices _courseServices;

        public CourseController(ICourseServices courseServices)
        {
            _courseServices = courseServices;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_courseServices.Get());
        }
               
        [HttpPost]
        public IActionResult Post([FromBody] Course course)
        {
            if (course.Name == null || course.Name == "")
                return BadRequest("La propiedad nombre no puede ser nula o vacia");

            _courseServices.Save(course);
            return Ok();
        }
        
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] Guid id,[FromBody] Course course)
        {
            if (course.Name == null || course.Name == "")
                return BadRequest("La propiedad nombre no puede ser nula o vacia");

            _courseServices.Update(id, course);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id) 
        {
            _courseServices.Delete(id);
            return Ok();
        }
    }
}
