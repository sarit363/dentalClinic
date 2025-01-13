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
    public class TurnRepository : ITurnRepository
    {
        private readonly DataContext context=new DataContext();
        public async Task<List<turn>> GetAllAsync()
        {
            return await context.Turn.Include(p => p.patient).ToListAsync();
        }
        public async Task AddAsync(turn turn)
        {
            context.Turn.Add(turn);
            await context.SaveChangesAsync();
        }
        public turn GetById(string id)
        {
            return context.Turn.FirstOrDefault(x => x.Id == id);
        }

        public void Remove(turn turn)
        {
            context.Turn.Remove(turn);
        }
        public async Task<turn> UpdateAsync(string id, turn NewTurn)
        {
            var list = await context.Turn.ToListAsync();
            var index = list.FindIndex(x => x.Id == id);
            if (index == -1)
            {
                return null;
            }
            list[index] = NewTurn;
            context.SaveChangesAsync();
            return list[index];
        }

        public turn Update(int id, turn NewTurn)
        {
            throw new NotImplementedException();
        }
    }
}
