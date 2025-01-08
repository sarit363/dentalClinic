using dental_clinic.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dental_clinic.Core.services
{
    public interface IDentistServices
    {
        public IEnumerable<dentist> GetList();
        public dentist GetById(string id);
        public void Add(dentist dentist);
        public void Remove(dentist dentist);
        public dentist Update(int id, dentist dentist);
    }
}
