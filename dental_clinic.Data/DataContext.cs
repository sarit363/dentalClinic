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
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=DC_DB");
            //optionsBuilder.LogTo(m => Console.WriteLine(m));
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<patient>()
                .HasOne(c => c.user)
                .WithMany() // או WithOne אם זה 1:1
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict); // הגבלת מחיקה

            modelBuilder.Entity<dentist>()
                .HasOne(d => d.user)
                .WithMany() // או WithOne אם זה 1:1
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict); // הגבלת מחיקה

            modelBuilder.Entity<User>(b =>
            {
                b.Property(e => e.Role)
                    .HasConversion(
                        v => v.ToString(), // המרה לstring
                        v => Enum.Parse<eRole>(v)); // המרה חזרה לenum
            });
        }

    }
}