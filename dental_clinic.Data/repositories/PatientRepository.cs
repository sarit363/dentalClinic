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
        public DbSet<patient> GetAll()
        {   
            return context.Patients;
        }
        public void Add(patient patient)
        {
            context.Patients.Add(patient);
        }
        public patient GetById(int id)
        {
            return context.Patients.FirstOrDefault(p => p.Id == id);
        }

        public void Remove(patient patient)
        {
            context.Patients.Remove(patient);
        }
        public void Update(patient updatedPatient)
        {
            var existingPatient = context.Patients.FirstOrDefault(d => d.Id == updatedPatient.Id);

            if (existingPatient != null)
            {
                // עדכון כל השדות של האובייקט הקיים לפי האובייקט החדש
                existingPatient.Name = updatedPatient.Name;
                existingPatient.Email = updatedPatient.Email;
                existingPatient.Phone_number = updatedPatient.Phone_number;
                existingPatient.Status = updatedPatient.Status;
                existingPatient.Id = updatedPatient.Id;
                existingPatient.Address = updatedPatient.Address;



                // שמירת העדכון בבסיס הנתונים
                context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException($"Dentist with ID {updatedPatient.Id} not found.");
            }
        }

        List<patient> IPatientRepository.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
