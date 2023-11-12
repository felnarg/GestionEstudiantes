
using Domain.Models;

namespace Application.Interfaces
{
    public interface IRepository<T>
    {
        public IEnumerable<T> Get();
        public Task Save(T entity);
        public Task Update(Guid id, T entity);
        public Task Delete(Guid id);
        public string GetDailyStudent(Guid id);
    }
}
