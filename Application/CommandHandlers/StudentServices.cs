
using Domain.Models;
using Infrastructure.DbStudentContext;
namespace Application.CommandHandlers
{
    public class StudentServices : IStudentServices
    {
        protected readonly StudentsContext context;

        public StudentServices(StudentsContext dbcontext)
        {
            context = dbcontext;
        }
        public IEnumerable<Student> Get()
        {
            return context.Students;
        }

        public IEnumerable<Student> StudentIdFilter(Guid id)
        {
            var StudentId = context.Students.Find(id);
            var CourseId = context.Courses.Find(id);
            if (StudentId != null && CourseId == null)
            {
                var filter = context.Students.Where(p => p.StudentId == id);
                return filter.ToList();
            }
            if (CourseId != null && StudentId == null)
            {
                var filter = context.Students.Where(p => p.CourseId == id);
                return filter.ToList();
            }
            //return NotFound();
            return Enumerable.Empty<Student>();
            //return context.Students; //revisar como retornar un badrequest
        }

        public IEnumerable<Student> GetStudentAgeContiditions(string condition)
        {
            //string request three parts separation =  string/to/number = 0/1/2
            string[] parts = condition.Split("to", StringSplitOptions.None);

            if (parts.Length == 2)
            {
                string keyword = parts[0].ToString();
                if (int.TryParse(parts[1], out int number))
                {
                    if (keyword == "igual")
                    {
                        var filter = context.Students.Where(p => p.Age == number);
                        return filter.ToList();
                    }
                    if (keyword == "mayor")
                    {
                        var filter = context.Students.Where(p => p.Age > number);
                        return filter.ToList();
                    }
                    if (keyword == "menor")
                    {
                        var filter = context.Students.Where(p => p.Age < number);
                        return filter.ToList();
                    }
                    if (keyword == "mayoroigual")
                    {
                        var filter = context.Students.Where(p => p.Age >= number);
                        return filter.ToList();
                    }
                    if (keyword == "menoroigual")
                    {
                        var filter = context.Students.Where(p => p.Age <= number);
                        return filter.ToList();
                    }
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
    }    
}
