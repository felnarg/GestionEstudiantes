
using System.Text.Json.Serialization;

namespace Domain.Models;

public class Course
{
    public Guid CourseId { get; set; }
    public string? Name { get; set; }

    [JsonIgnore]
    public virtual ICollection<Student>? Student { get; set; }
}