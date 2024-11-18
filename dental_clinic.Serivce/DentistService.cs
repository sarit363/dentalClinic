using dental_clinic.Core.entities;
using dental_clinic.Core.reposetories;
using dental_clinic.Core.services;
using dental_clinic.Data.repositories;
using dental_clinic.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dental_clinic.Serivce
{
    public class DentistService : IDentistServices
    {
        private readonly IDentistRepository _dentistRepository;
        public DentistService(IDentistRepository dentistRepository)
        {
            _dentistRepository = dentistRepository;
        }

        public List<dentist> GetList()
        {
           return _dentistRepository.GetAll();
        }
    }
    
}
 