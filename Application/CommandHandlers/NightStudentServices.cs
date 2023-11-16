
using Application._Resource;
using Application.Interfaces;
using Domain.Models;
using Infrastructure.DbStudentContext;

namespace Application.CommandHandlers
{
    public class NightStudentServices : Application.Interfaces.IRepository<NightStudent>, Infrastructure.Interfaces.IRepository<NightStudent>
    {
        //protected readonly StudentsContext context;
        private readonly Infrastructure.Interfaces.IRepository<NightStudent> _context;

        public NightStudentServices(Infrastructure.Interfaces.IRepository<NightStudent> dbcontext)
        {
            _context = dbcontext;
        }

        public IEnumerable<NightStudent> Get()
        {
            return _context.GetAll();
        }

        public async Task Save(NightStudent nightStudent)
        {       
            _context.Add(nightStudent);
        }
        public async Task Update(Guid id, NightStudent nightStudent)
        {
            var DB = GetAll();
            var actualNightStudent = DB.FirstOrDefault(p => p.NightStudentId == id);            
            if (actualNightStudent != null)
            {
                actualNightStudent.Name = nightStudent.Name;
                actualNightStudent.CourseId = nightStudent.CourseId;
                actualNightStudent.Age = nightStudent.Age;
                _context.Update(id, actualNightStudent);
            }
        }

        public async Task Delete(Guid id)
        {
            var DB = GetAll();
            var actualNightStudent = DB.FirstOrDefault(p => p.NightStudentId == id);
            if (actualNightStudent != null)
            {
                _context.Delete(id);
            }
        }
        public string GetDailyStudent(Guid id)
        {
            var DB = GetAll();
            var actualNightStudent = DB.FirstOrDefault(p => p.NightStudentId == id);
            if (actualNightStudent != null)
            {
                return string.Format(Resource1.DailyClassNight, actualNightStudent.Name);
            }
            else
                return Resource1.IdNotFound;
        }

        public NightStudent GetById(Guid id)
        {
            return _context.GetById(id);
        }

        public IEnumerable<NightStudent> GetAll()
        {
            return _context.GetAll();
        }

        public void Add(NightStudent entity)
        {
            _context.Add(entity);
        }

        void Infrastructure.Interfaces.IRepository<NightStudent>.Update(Guid id, NightStudent entity)
        {
            _context.Update(id, entity);
        }

        bool Infrastructure.Interfaces.IRepository<NightStudent>.Delete(Guid id)
        {
            return _context.Delete(id);
        }
    }
}
