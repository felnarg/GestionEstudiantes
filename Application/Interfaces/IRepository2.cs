namespace Application.Interfaces
{
    public interface IRepository2<T> where T : class
    {
        T GetById(Guid id);

        IEnumerable<T> GetAll();

        void Add(T entity);

        void Update(Guid id, T entity);

        bool Delete(Guid id);
    }
}
