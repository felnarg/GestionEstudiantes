
using System.Text.Json.Serialization;

namespace Domain.Models;

public class NightStudent
{
    public Guid NightStudentId { get; set; }
    public Guid CourseId { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    [JsonIgnore]
    public virtual Course? Course { get; set; }
}
