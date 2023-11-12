using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Application._Resource.Validations;
using Application.Interfaces;

namespace Gestion_Estudiantes.Controllers
{
    [Route("[controller]")]
    public class NightStudentController : ControllerBase
    {
        private readonly IRepository<NightStudent> _nightStudentServices;

        public NightStudentController(IRepository<NightStudent> nightStudentServices)
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
            _nightStudentServices.Save(nightStudent);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] Guid id, [FromBody] NightStudent nightStudent)
        {
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
