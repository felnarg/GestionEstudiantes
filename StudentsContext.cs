using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi;

public class StudentsContext: DbContext
{
    public DbSet<Course> Courses {get;set;}
    public DbSet<Student> Students {get;set;}

    public StudentsContext(DbContextOptions<StudentsContext> options) :base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { 
        modelBuilder.Entity<Course>(course=> 
        {
            course.ToTable("Courses");

            course.HasKey(p=> p.CourseId);

            course.Property(p=> p.Name).IsRequired().HasMaxLength(50);

        });
 
        modelBuilder.Entity<Student>(student=>
        {
            student.ToTable("Student");

            student.HasKey(p=> p.StudentId);

            student.HasOne(p=> p.Course).WithMany(p=> p.Student).HasForeignKey(p=> p.CourseId).OnDelete(DeleteBehavior.Cascade).IsRequired();

            student.Property(p=> p.Name).IsRequired().HasMaxLength(50);

            student.Property(p=> p.Age).IsRequired();
        });

    }

}