
namespace Infrastructure.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T GetById(Guid id);

        IEnumerable<T> GetAll();

        void Add(T entity);

        void Update(Guid id, T entity);

        bool Delete(Guid id);
    }
}
