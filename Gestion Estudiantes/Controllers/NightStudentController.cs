using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Application._Resource.Validations;

namespace Gestion_Estudiantes.Controllers
{
    [Route("[controller]")]
    public class NightStudentController : ControllerBase
    {
        private readonly INightStudentServices _nightStudentServices;

        public NightStudentController(INightStudentServices nightStudentServices)
        {
            _nightStudentServices = nightStudentServices;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_nightStudentServices.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] NightStudent nightStudent)
        {
            Validations.FieldValidation(nameof(nightStudent.Name), nightStudent.Name);
            _nightStudentServices.Save(nightStudent);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] Guid id, [FromBody] NightStudent nightStudent)
        {
            if (nightStudent.Name == null || nightStudent.Name == "")
                return BadRequest("La propiedad nombre no puede ser nula o vacia");

            _nightStudentServices.Update(id, nightStudent);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _nightStudentServices.Delete(id);
            return Ok();
        }
    }
}
