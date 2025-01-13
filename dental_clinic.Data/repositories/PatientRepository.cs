using dental_clinic.Core.reposetories;
using dental_clinic.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dental_clinic.Data.repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly DataContext context = new DataContext();
        public async Task<List<patient>> GetAllAsync()
        {
            return await context.Patients.Include(d => d.TurnId).ToListAsync();
        }
        public async Task AddAsync(patient patient)
        {
            context.Patients.Add(patient);
             await context.SaveChangesAsync();
        }
        public patient GetById(string id)
        {
            return context.Patients.FirstOrDefault(p => p.Id == id);
        }

        public void Remove(patient patient)
        {
            context.Patients.Remove(patient);
        }
        public async Task<patient> UpdateAsync(string id, patient NewPatient)
        {
            var list = await context.Patients.ToListAsync();
            var index = list.FindIndex(x => x.Id == id);
            if (index == -1)
            {
                return null;
            }
            list[index] = NewPatient;
            context.SaveChangesAsync();
            return list[index];
        }

        public patient Update(int id, patient NewPatient)
        {
            throw new NotImplementedException();
        }
    }
}
