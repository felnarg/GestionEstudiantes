
using Application.Validations.Enums;
using Application.Validations;
using Azure.Core;
using Domain.Models;
using Infrastructure.DbStudentContext;
using Microsoft.IdentityModel.Tokens;
using Application.Interfaces;

namespace Application.CommandHandlers
{
        public class CourseServices : ICourseServices, Infrastructure.Interfaces.IRepository<Course>
    {
            protected readonly StudentsContext context;
            private readonly Infrastructure.Interfaces.IRepository<Course> courseRepository;

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
                    Add(course);
                    //context.SaveChanges();
                    return EnumCourseRequest.Posibilities.correct;
                }
                           
            }
            public EnumCourseRequest.Posibilities Update(Guid id, Course course)
            {
                var validation = Validations.Validations.FieldValidation(course.Name!);
                if (!validation)
                    return EnumCourseRequest.Posibilities.badName;
                var DB = GetAll();
                var actualCourse = DB.FirstOrDefault(p => p.CourseId == id);
            if (actualCourse != null)
                {
                    actualCourse.Name = course.Name;
                    Update(id, actualCourse);
                    //courseRepository.SaveChanges();
                    return EnumCourseRequest.Posibilities.correct;
                }
                else
                    return EnumCourseRequest.Posibilities.badIdCourse;
            }

            public bool Delete(Guid id)
            {
                var condition = false;               
                condition = Delete(id);
                return condition;                      
            }

        public Course GetById(Guid id)
        {
            return courseRepository.GetById(id);
        }

        public IEnumerable<Course> GetAll()
        {
            return courseRepository.GetAll().ToList();
        }

        public void Add(Course entity)
        {
            courseRepository.Add(entity);
        }

        void Infrastructure.Interfaces.IRepository<Course>.Update(Guid id, Course entity)
        {
            courseRepository.Update(id, entity);
        }

        bool Infrastructure.Interfaces.IRepository<Course>.Delete(Guid id)
        {
            var condition = false;
            condition = courseRepository.Delete(id);
            return (condition);
        }
    }
}
