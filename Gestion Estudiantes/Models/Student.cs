using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace webapi.Models;

public class Student
{
    public Guid StudentId {get;set;}
    public Guid CourseId {get;set;}
    public string Name {get;set;}
    public int Age {get;set;}
    [JsonIgnore]
    public virtual Course Course {get;set;}
}
