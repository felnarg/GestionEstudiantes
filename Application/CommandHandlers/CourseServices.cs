
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
            //protected readonly StudentsContext context;
            private readonly Infrastructure.Interfaces.IRepository<Course> _courseRepository;

            public CourseServices(Infrastructure.Interfaces.IRepository<Course> courseRepository)
            {
                _courseRepository = courseRepository;
            }

            public IEnumerable<Course> Get()
            {
                return GetAll();
            }

            public EnumCourseRequest.Posibilities Save(Course course)
            {
            var DB = GetAll();
            var actualCourse = DB.FirstOrDefault(p => p.CourseId == course.CourseId);            
                if (actualCourse != null)
                    return EnumCourseRequest.Posibilities.duplicateIdKey;
                if (course.Name!.IsNullOrEmpty())                
                    return EnumCourseRequest.Posibilities.badName;                                   
                else
                {
                    Add(course);
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
            return _courseRepository.GetById(id);
        }

        public IEnumerable<Course> GetAll()
        {
            return _courseRepository.GetAll().ToList();
        }

        public void Add(Course entity)
        {
            _courseRepository.Add(entity);
        }

        void Infrastructure.Interfaces.IRepository<Course>.Update(Guid id, Course entity)
        {
            _courseRepository.Update(id, entity);
        }

        bool Infrastructure.Interfaces.IRepository<Course>.Delete(Guid id)
        {
            var condition = false;
            condition = _courseRepository.Delete(id);
            return (condition);
        }
    }
}
