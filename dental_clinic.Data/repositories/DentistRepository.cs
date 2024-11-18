using dental_clinic.Core.reposetories;
using dental_clinic.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dental_clinic.Data.repositories
{
    public class DentistRepository: IDentistRepository
    {
        private readonly DataContext _context;
        public DentistRepository(DataContext context)
        {
           _context=context;
        }
        public List<dentist> GetAll()
        {
            return _context.Dentists;
        }
    }
}
