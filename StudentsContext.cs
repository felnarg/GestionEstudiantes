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
        List<Course> courseInit = new List<Course>();
        courseInit.Add(new Course() { CourseId = Guid.Parse("22f973e1-f297-4884-b522-2540b44750f5"), Name = "sexto"});

        modelBuilder.Entity<Course>(course=> 
        {
            course.ToTable("Course");

            course.HasKey(p=> p.CourseId);

            course.Property(p=> p.Name).IsRequired().HasMaxLength(50);

            course.HasData(courseInit);

        });

        List<Student> studentInit = new List<Student>();
        studentInit.Add(new Student() { StudentId = Guid.Parse("22f973e1-f297-4884-b522-2540b44750f4"), CourseId = Guid.Parse("22f973e1-f297-4884-b522-2540b44750f5"), Name = "William lasso", Age = 10});

        modelBuilder.Entity<Student>(student=>
        {
            student.ToTable("Student");

            student.HasKey(p=> p.StudentId);

            student.HasOne(p=> p.Course).WithMany(p=> p.Student).HasForeignKey(p=> p.CourseId)
            .OnDelete(DeleteBehavior.Cascade).IsRequired();

            student.Property(p=> p.Name).IsRequired().HasMaxLength(50);

            student.Property(p=> p.Age).IsRequired();

            student.HasData(studentInit);
        });

    }

}