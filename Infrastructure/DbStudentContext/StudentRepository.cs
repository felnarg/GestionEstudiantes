using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Interfaces;

namespace Infrastructure.DbStudentContext
{
    public class StudentRepository<T> : IRepository<T> where T : class
    {
        private readonly StudentsContext _context;

        public StudentRepository(StudentsContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public bool Delete(Guid id)
        {
            var actualEntity = _context.Set<T>().Find(id);
            if (actualEntity != null)
            {
                _context.Remove(actualEntity!);
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T GetById(Guid id)
        {            
            return _context.Set<T>().Find(id)!;
        }

        public void Update(Guid id,T entity)
        {
            var actualEntity = _context.Set<T>().Find(id);

            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }
}
