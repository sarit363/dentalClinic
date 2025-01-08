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
        public IEnumerable<turn> GetAll()
        {
            return context.Turn.Include(p => p.patient);
        }
        public void Add(turn turn)
        {
            context.Turn.Add(turn);
            context.SaveChanges();
        }
        public turn GetById(string id)
        {
            return context.Turn.FirstOrDefault(x => x.Id == id);
        }

        public void Remove(turn turn)
        {
            context.Turn.Remove(turn);
        }
        public turn Update(string id, turn NewTurn)
        {
            var index = context.Turn.ToList().FindIndex(x => x.Id == id);
            if (index != -1)
            {
                context.Turn.ToList()[index] = NewTurn;
                context.SaveChanges();
                return context.Turn.ToList()[index];
            }
            return null;
        }

        public turn Update(int id, turn NewTurn)
        {
            throw new NotImplementedException();
        }
    }
}
