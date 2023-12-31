﻿using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Application.Interfaces;

namespace Gestion_Estudiantes.Controllers
{
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentServices _studentService;
        private readonly IRepository<Student> _studentRepository;

        public StudentController(IStudentServices studentService, IRepository<Student> studentRepository)
        {
            _studentService = studentService;
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_studentRepository.Get());
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
            _studentRepository.Save(student);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Student student)
        {
            _studentRepository.Update(id, student);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id) 
        {
            _studentRepository.Delete(id);
            return Ok();
        }

        [HttpGet("studentmorning/{id}")]
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
