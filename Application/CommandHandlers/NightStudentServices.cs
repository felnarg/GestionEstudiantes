﻿
using System.ComponentModel.DataAnnotations;
using Application._Resource.Validations;
using Domain.Models;
using Infrastructure.DbStudentContext;

namespace Application.CommandHandlers
{
    public class NightStudentServices : INightStudentServices
    {
        protected readonly StudentsContext context;

        public NightStudentServices(StudentsContext dbcontext)
        {
            context = dbcontext;
        }

        public IEnumerable<NightStudent> Get()
        {
            return context.NightStudents;
        }

        public async Task Save(NightStudent nightStudent)
        {
            //nightStudent.NightStudentId = Guid.NewGuid();            
            context.Add(nightStudent);
            context.SaveChanges();
            //await context.SaveChangesAsync();
        }
        public async Task Update(Guid id, NightStudent nightStudent)
        {
            var actualNightStudent = context.NightStudents.Find(id);
            if (actualNightStudent != null)
            {
                actualNightStudent.Name = nightStudent.Name;
                context.Update(actualNightStudent);
                context.SaveChanges();
            }
        }

        public async Task Delete(Guid id)
        {
            var actualNightStudent = context.NightStudents.Find(id);
            if (actualNightStudent != null)
            {
                context.Remove(actualNightStudent);
                context.SaveChanges();
            }
        }
    }
}
