
    using System.ComponentModel.DataAnnotations;
    using Application._Resource.Validations;
using Application._Resource.Validations.Enums;
using Azure.Core;
using Domain.Models;
    using Infrastructure.DbStudentContext;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

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

            public EnumCourseRequest.Posibilities Save(Course course)
            {
                var actualCourse = context.Courses.Find(course.CourseId);
                if (actualCourse != null)
                    return EnumCourseRequest.Posibilities.duplicateIdKey;
                if (course.Name!.IsNullOrEmpty())                
                    return EnumCourseRequest.Posibilities.badName;                                   
                else
                {
                    context.Add(course);
                    context.SaveChanges();
                    return EnumCourseRequest.Posibilities.correct;
                }
                           
            }
            public EnumCourseRequest.Posibilities Update(Guid id, Course course)
            {
                var validation = Validations.FieldValidation(course.Name!);
                if (!validation)
                    return EnumCourseRequest.Posibilities.badName;

                var actualCourse = context.Courses.Find(id);
                if (actualCourse != null)
                {
                    actualCourse.Name = course.Name;
                    context.Update(actualCourse);
                    context.SaveChanges();
                    return EnumCourseRequest.Posibilities.correct;
                }
                else
                    return EnumCourseRequest.Posibilities.badIdCourse;
            }

            public bool Delete(Guid id)
            {
                var actualCourse = context.Courses.Find(id);
            if (actualCourse != null)
            {
                context.Remove(actualCourse);
                context.SaveChanges();
                return true;
            }
            else
                return false;
            }
        }
    }
