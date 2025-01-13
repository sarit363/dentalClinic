﻿using dental_clinic.Core.reposetories;
using dental_clinic.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public dentist GetById(string id)
        {
            return _context.Dentists.FirstOrDefault(x => x.Id == id);
        }

        public void Remove(dentist dentist)
        {
            _context.Dentists.Remove(dentist);
        }
        public dentist Update(string id, dentist NewDentist)
        {
            var index = _context.Dentists.ToList().FindIndex(x => x.Id == id);
            if (index != -1)
            {
                _context.Dentists.ToList()[index] = NewDentist;
                _context.SaveChanges();
                return _context.Dentists.ToList()[index];
            }
            return null;
        }

        public dentist Update(int id, dentist NewDentist)
        {
            throw new NotImplementedException();
        }
    }
}
