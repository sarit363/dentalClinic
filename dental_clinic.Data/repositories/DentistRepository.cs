using dental_clinic.Core.reposetories;
using dental_clinic.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace dental_clinic.Data.repositories
{
    public class DentistRepository : IDentistRepository
    {
        private readonly DataContext _context = new DataContext();
        public async Task<List<dentist>> GetAllAsync()
        {
            return await _context.Dentists.Include(d => d.turns).ToListAsync();
        }
        public IEnumerable<turn> GetList()
        {
            return _context.Turn.Include(u => u.DoctorName);
        }
        public async Task AddAsync(dentist entist)
        {
            _context.Dentists.Add(entist);
            await _context.SaveChangesAsync();
        }

        public async Task<dentist> GetByIdAsync(string id)
        {
            return await _context.Dentists.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(dentist dentist)
        {
            _context.Dentists.Remove(dentist);
        }
        public async Task<dentist> UpdateAsync(string id, dentist NewDentist)
        {
            var list = await _context.Dentists.ToListAsync();
            var index = list.FindIndex(x => x.Id == id);
            if (index == -1)
            {
                return null;
            }
            list[index] = NewDentist;
            _context.SaveChangesAsync();
            return list[index];
        }

        public dentist Update(int id, dentist NewDentist)
        {
            throw new NotImplementedException();
        }
    }
}
