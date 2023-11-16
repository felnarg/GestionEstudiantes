
using Application._Resource;
using Application.Validations;
using Application.Interfaces;
using Domain.Models;
using Infrastructure.DbStudentContext;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Application.CommandHandlers
{
    public class StudentServices : IStudentServices, IRepository<Student>, Infrastructure.Interfaces.IRepository<Student>
    {
        private readonly Infrastructure.Interfaces.IRepository<Student> _context;

        public StudentServices(Infrastructure.Interfaces.IRepository<Student> dbcontext)
        {
            _context = dbcontext;
        }
        public IEnumerable<Student> Get()
        {
            return GetAll();
        }

        public IEnumerable<Student> StudentIdFilter(Guid id)
        {
            var DB = GetAll();
            var StudentId = DB.FirstOrDefault(p => p.StudentId == id);
            var CourseId = DB.FirstOrDefault(p => p.CourseId == id);
            if (StudentId != null && CourseId == null)
            {
                var filter = DB.Where(p => p.StudentId == id);
                return filter.ToList();
            }
            if (CourseId != null && StudentId == null)
            {
                var filter = DB.Where(p => p.CourseId == id);
                return filter.ToList();
            }
            return Enumerable.Empty<Student>();
        }

        public IEnumerable<Student> GetStudentAgeContiditions(string condition)
        {
            //string request three parts separation =  string/to/number = 0/1/2
            string[] parts = condition.Split(Constants.KEY_WORD_AGE_CONDITION_SERVICE, StringSplitOptions.None);
            var DB = GetAll();
            if (parts.Length == 2)
            {
                string keyword = parts[0].ToString();
                if (int.TryParse(parts[1], out int number))
                {
                    if (keyword == Constants.EQUAL){var filter = DB.Where(p => p.Age == number);
                        return filter.ToList();}
                    if (keyword == Constants.GREATER){var filter = DB.Where(p => p.Age > number);
                        return filter.ToList();}
                    if (keyword == Constants.LESS){var filter = DB.Where(p => p.Age < number);
                        return filter.ToList();}
                    if (keyword == Constants.GREATER_THAN){var filter = DB.Where(p => p.Age >= number);
                        return filter.ToList();}
                    if (keyword == Constants.LESS_THAN){var filter = DB.Where(p => p.Age <= number);
                        return filter.ToList();}
                }
            }
            return Enumerable.Empty<Student>();
        }

        public async Task Save(Student student)
        {
            //student.StudentId = Guid.NewGuid();
            context.Students.Add(student);
            context.SaveChanges();
        }

        public async Task Update(Guid id, Student student)
        {
            var actualStudent = context.Students.Find(id);
            if (actualStudent == null)
                context.SaveChanges();
            if (actualStudent != null)
            {
                actualStudent.CourseId = student.CourseId;
                actualStudent.Name = student.Name;
                actualStudent.Age = student.Age;
                context.Update(actualStudent);
                context.SaveChanges();
            }
        }
        public async Task Delete(Guid id)
        {
            var actualStudent = context.Students.Find(id);
            if (actualStudent != null)
            {
                context.Remove(actualStudent);
                context.SaveChanges();
            }
        }
        public string GetDailyStudent(Guid id)
        {
            var actualStudent = context.Students.Find(id);
            if ( actualStudent != null)
            {
                return string.Format(Resource1.DailyClass, actualStudent.Name);
            }
            else
                return Resource1.IdNotFound;
        }

        public Student GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Add(Student entity)
        {
            throw new NotImplementedException();
        }

        void Infrastructure.Interfaces.IRepository<Student>.Update(Guid id, Student entity)
        {
            throw new NotImplementedException();
        }

        bool Infrastructure.Interfaces.IRepository<Student>.Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }    
}
