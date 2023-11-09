using Domain.Models;

public interface IStudentServices
{
    public IEnumerable<Student> Get();
    public IEnumerable<Student> StudentIdFilter(Guid id);
    public IEnumerable<Student> GetStudentAgeContiditions(string condition);
    public Task Save(Student student);
    public Task Update(Guid id, Student student);
    public Task Delete(Guid id);
}