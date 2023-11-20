using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Application.Validations;
using Application.Interfaces;

namespace Gestion_Estudiantes.Controllers
{
    [Route("[controller]")]
    public class NightStudentController : ControllerBase
    {        
        private readonly IRepository<NightStudent> _studentRepository;

        public NightStudentController(IRepository<NightStudent> studentRepository)
        {            
            _studentRepository = studentRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_studentRepository.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] NightStudent nightStudent)
        {
            _studentRepository.Save(nightStudent);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] Guid id, [FromBody] NightStudent nightStudent)
        {
            _studentRepository.Update(id, nightStudent);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _studentRepository.Delete(id);
            return Ok();
        }

        [HttpGet("studentnight/{id}")]
        public IActionResult GetDailyStudentMorning(Guid id)
        {
            var validation = _studentRepository.GetDailyStudent(id);
            if (validation == Resource.IdNotFound)
                return BadRequest(validation);
            else
                return Ok(validation);
        }
    }
}
