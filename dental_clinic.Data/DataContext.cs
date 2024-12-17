using dental_clinic.entities;
using Microsoft.EntityFrameworkCore;

namespace dental_clinic
{
    public class DataContext : DbContext
    {
        public DbSet<dentist> Dentists { get; set; }
        public DbSet<patient> Patients { get; set; }
        public DbSet<turn> Turn { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=DentalClinic_new_db");
            //optionsBuilder.LogTo(m => Console.WriteLine(m));
        }

    }
}
