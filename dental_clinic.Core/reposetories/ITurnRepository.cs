using dental_clinic.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dental_clinic.Core.reposetories
{
    public interface ITurnRepository
    {
        public IEnumerable<turn> GetAll();
        public void Add(turn turn);
        public turn GetById(string id);
        public void Remove(turn turn);
        public turn Update(int id, turn NewTurn);
    }
}
