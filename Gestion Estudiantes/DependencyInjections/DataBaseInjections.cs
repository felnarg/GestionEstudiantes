using Application.Interfaces;
using Domain.Models;
using Infrastructure.DbStudentContext;

namespace Gestion_Estudiantes.DependencyInjections
{
    public static class DataBaseInjections
    {
        public static void InjectDb(this WebApplicationBuilder builder)
        {
            builder.Services.AddSqlServer<StudentsContext>(builder.Configuration.GetConnectionString("dbstudent"));
            builder.Services.AddScoped<IRepository2<Course>, StudentRepository<Course>>();
            builder.Services.AddScoped<IRepository2<NightStudent>, StudentRepository<NightStudent>>();
            builder.Services.AddScoped<IRepository2<Student>, StudentRepository<Student>>();
        }

    }
}
