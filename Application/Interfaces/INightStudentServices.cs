using Domain.Models;

public interface INightStudentServices
{
    public IEnumerable<NightStudent> Get();
    public Task Save(NightStudent nightStudent);
    public Task Update(Guid id, NightStudent nightStudent);
    public Task Delete(Guid id);
}