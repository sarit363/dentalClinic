using dental_clinic.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dental_clinic.Data.repositories
{
    public class TurnRepository
    {
        private readonly DataContext context=new DataContext();
        public List<turn> GetAll()
        {
            return context.Turn;
        }
    }
}
