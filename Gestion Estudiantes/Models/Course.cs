using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace webapi.Models;

public class Course
{
    public Guid CourseId {get;set;}
    public string Name {get;set;}

    [JsonIgnore]
    public virtual ICollection<Student> Student {get;set;}
}