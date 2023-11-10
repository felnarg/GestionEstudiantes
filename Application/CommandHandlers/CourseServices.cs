﻿
    using System.ComponentModel.DataAnnotations;
    using Application._Resource.Validations;
    using Domain.Models;
    using Infrastructure.DbStudentContext;

    namespace Application.CommandHandlers
    {
        public class CourseServices : ICourseServices
        {
            protected readonly StudentsContext context;

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
                //course.CourseId = Guid.NewGuid();            
                context.Add(course);
                context.SaveChanges();
                //await context.SaveChangesAsync();
            }
            public async Task Update(Guid id, Course course)
            {
                var actualCourse = context.Courses.Find(id);
                if (actualCourse != null)
                {
                    actualCourse.Name = course.Name;
                    context.Update(actualCourse);
                    context.SaveChanges();
                }
            }

            public async Task Delete(Guid id)
            {
                var actualCourse = context.Courses.Find(id);
                if (actualCourse != null)
                {
                    context.Remove(actualCourse);
                    context.SaveChanges();
                }
            }
        }
    }
