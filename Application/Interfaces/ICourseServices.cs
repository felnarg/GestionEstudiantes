using Domain.Models;

public interface ICourseServices
{
    public IEnumerable<Course> Get();
    public Task Save(Course course);
    public Task Update(Guid id, Course course);
    public Task Delete(Guid id);
}