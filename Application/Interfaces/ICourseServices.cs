using Application.Validations.Enums;
using Domain.Models;

public interface ICourseServices
{
    public IEnumerable<Course> Get();
    public EnumCourseRequest.Posibilities Save(Course course);
    public EnumCourseRequest.Posibilities Update(Guid id, Course course);
    public bool Delete(Guid id);
}