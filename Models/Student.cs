using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models;

public class Student
{
    public Guid StudentId {get;set;}
    public Guid CourseId {get;set;}
    public string Name {get;set;}
    public int Age {get;set;}
    public virtual Course Course {get;set;}
}
