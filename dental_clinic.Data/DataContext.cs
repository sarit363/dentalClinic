using dental_clinic.Core.entities;
using dental_clinic.entities;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace dental_clinic
{
    public class DataContext : DbContext
    {
        public DbSet<dentist> Dentists { get; set; }
        public DbSet<patient> Patients { get; set; }
        public DbSet<turn> Turn { get; set; }
        public DbSet<User> User { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=DentalClinic_new_db");
            //optionsBuilder.LogTo(m => Console.WriteLine(m));
        }
    }
}