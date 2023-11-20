
using Application.Interfaces;
using Application.Validations.Enums;
using Domain.Models;
namespace Application.CommandHandlers
{
    public class CourseServices : ICourseServices, IRepository2<Course>
    {
            private readonly IRepository2<Course> _courseRepository;

            public CourseServices(IRepository2<Course> courseRepository)
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
                if (string.IsNullOrEmpty(course.Name!))                
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
                    _courseRepository.Update(id, actualCourse);
                    //courseRepository.SaveChanges();
                    return EnumCourseRequest.Posibilities.correct;
                }
                else
                    return EnumCourseRequest.Posibilities.badIdCourse;
            }

            public bool Delete(Guid id)
            {
                var condition = false;               
                condition = _courseRepository.Delete(id);
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

        void IRepository2<Course>.Update(Guid id, Course entity)
        {
            _courseRepository.Update(id, entity);
        }

        bool IRepository2<Course>.Delete(Guid id)
        {
            var condition = false;
            condition = _courseRepository.Delete(id);
            return (condition);
        }
    }
}
