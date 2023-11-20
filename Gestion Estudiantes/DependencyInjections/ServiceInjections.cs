using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure.DbStudentContext;
using Application.CommandHandlers;
using Application.Interfaces;
using Domain.Models;


namespace Gestion_Estudiantes.DependencyInjections
{
    public static class ServiceInjections
    {
        public static void InjectServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ICourseServices, CourseServices>();
            builder.Services.AddScoped<IStudentServices, StudentServices>();
            builder.Services.AddScoped<IRepository<NightStudent>, NightStudentServices>();
            builder.Services.AddScoped<IRepository<Student>, StudentServices>();
        }
        
    }
}
