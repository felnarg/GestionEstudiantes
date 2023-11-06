using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using webapi;
using webapi.Models;

namespace Gestion_Estudiantes.Services
{
    public class StudentServices : IStudentServices
    {
        StudentsContext context;

        public StudentServices(StudentsContext dbcontext)
        {
            context = dbcontext;
        }
        public IEnumerable<Student> Get()
        {
            return context.Students;
        }

        public async Task Save(Student student)
        {
            student.StudentId = Guid.NewGuid();
            context.Add(student);
            await context.SaveChangesAsync();
        }

        public async Task Update(Guid id, Student student)
        {
            var actualStudent = context.Students.Find(id);
            if (actualStudent != null)
            {
                actualStudent.Name = student.Name;
                await context.SaveChangesAsync();
            }
            await context.SaveChangesAsync();
        }
        public async Task Delete(Guid id)
        {
            var actualStudent = context.Students.Find(id);
            if (actualStudent != null)
            {
                context.Remove(actualStudent);
                await context.SaveChangesAsync();
            }

            await context.SaveChangesAsync();
        }
    }

    public interface IStudentServices
    {
        public IEnumerable<Student> Get();
        public Task Save(Student student);
        public Task Update(Guid id, Student student);
        public Task Delete(Guid id);
    }
}
