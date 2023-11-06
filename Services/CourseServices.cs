using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using webapi;
using webapi.Models;

namespace Gestion_Estudiantes.Services
{
    public class CourseServices : ICourseServices
    {
        StudentsContext context;

        public CourseServices(StudentsContext dbcontext)
        {
            context = dbcontext;
        }
        public IEnumerable<Course> Get()
        {
            return context.Courses;
        }

        public async Task Save(Course course)
        {
            context.Add(course);
            await context.SaveChangesAsync();
        }

        public async Task Update(Guid id, Course course)
        {
            var actualCourse = context.Courses.Find(id);
            if (actualCourse!=null)
            {
                actualCourse.Name = course.Name;
                
                await context.SaveChangesAsync();
            }
                
            await context.SaveChangesAsync();
        }
        public async Task Delete(Guid id)
        {
            var actualCourse = context.Courses.Find(id);
            if (actualCourse != null)
            {
                context.Remove(actualCourse);
                await context.SaveChangesAsync();
            }

            await context.SaveChangesAsync();
        }
    }

    public interface ICourseServices
    {
        public IEnumerable<Course> Get();
        public Task Save(Course course);
        public Task Update(Guid id, Course course);
        public Task Delete(Guid id);
    }
}
