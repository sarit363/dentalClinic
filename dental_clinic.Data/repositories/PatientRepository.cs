using dental_clinic.Core.reposetories;
using dental_clinic.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dental_clinic.Data.repositories
{
    public class PatientRepository: IPatientRepository
    {
        private readonly DataContext _context;
        public PatientRepository(DataContext context)
        {
            _context = context;
        }
        public List<patient> GetAll()
        {
            return _context.Patients;
        }
    }
}
