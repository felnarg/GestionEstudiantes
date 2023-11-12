using Application._Resource.Validations.Enums;
using Domain.Models;

public interface ICourseServices
{
    public IEnumerable<Course> Get();
    public bool Save(Course course);
    public EnumCourseRequest.Posibilities Update(Guid id, Course course);
    public bool Delete(Guid id);
}