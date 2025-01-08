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
        public IEnumerable<patient> GetAll()
        {   
            return context.Patients;
        }
        public void Add(patient patient)
        {
            context.Patients.Add(patient);
            context.SaveChanges();
        }
        public patient GetById(string id)
        {
            return context.Patients.FirstOrDefault(p => p.Id == id);
        }

        public void Remove(patient patient)
        {
            context.Patients.Remove(patient);
        }
        public patient Update(string id, patient NewPatient)
        {
            var index = context.Patients.ToList().FindIndex(x => x.Id == id);
            if (index != -1)
            {
                context.Patients.ToList()[index] = NewPatient;
                context.SaveChanges();
                return context.Patients.ToList()[index];
            }
            return null;
        }

        public patient Update(int id, patient NewPatient)
        {
            throw new NotImplementedException();
        }
    }
}
