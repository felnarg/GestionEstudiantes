using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Application._Resource.Validations;
using System.Resources;
using Application._Resource.Validations.Enums;

namespace Gestion_Estudiantes.Controllers
{
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseServices _courseServices;

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
            var validation = _courseServices.Save(course);
            if (validation == EnumCourseRequest.Posibilities.correct)                            
                return Ok(Resource.OkSave);
            else if (validation == EnumCourseRequest.Posibilities.badName)
                return BadRequest(string.Format(Resource.FieldVerify, Constants.NAME));
            else 
                return BadRequest(Resource.DuplicateKey);
        }
        
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] Guid id,[FromBody] Course course)
        {            
            var validation = _courseServices.Update(id, course);
            if (validation == EnumCourseRequest.Posibilities.correct)
                return Ok(Resource.OkUpdate);
            else if (validation == EnumCourseRequest.Posibilities.badName)
                return BadRequest(string.Format(Resource.FieldVerify, nameof(course.Name)));
            else
                return BadRequest(Resource.IdNotFound);                
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id) 
        {            
            var validation = _courseServices.Delete(id);
            if (validation)
                return Ok(Resource.OkRemove);
            else
                return BadRequest(Resource.IdNotFound);
        }
    }
}
