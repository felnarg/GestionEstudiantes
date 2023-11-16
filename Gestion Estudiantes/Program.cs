using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure.DbStudentContext;
using Application.CommandHandlers;
using Application.Interfaces;
using Domain.Models;
using Gestion_Estudiantes.DependencyInjections;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Inject();

var app = builder.Build();

app.MapGet("/dbconnection", async ([FromServices] StudentsContext dbcontext) =>
{
    dbcontext.Database.EnsureCreated();
    return Results.Ok($"Base de datos en memoria: {dbcontext.Database.IsInMemory()}");
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
