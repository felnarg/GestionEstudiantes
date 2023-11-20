using Domain.Models;
using Infrastructure.DbStudentContext;

namespace Gestion_Estudiantes.DependencyInjections
{
    public static class DataBaseInjections
    {
        public static void InjectDb(this WebApplicationBuilder builder)
        {
            builder.Services.AddSqlServer<StudentsContext>(builder.Configuration.GetConnectionString("dbstudent"));
            builder.Services.AddScoped<Infrastructure.Interfaces.IRepository<Course>, StudentRepository<Course>>();
            builder.Services.AddScoped<Infrastructure.Interfaces.IRepository<NightStudent>, StudentRepository<NightStudent>>();
            builder.Services.AddScoped<Infrastructure.Interfaces.IRepository<Student>, StudentRepository<Student>>();
        }

    }
}
