using dental_clinic.entities;
using Microsoft.EntityFrameworkCore;

namespace dental_clinic
{
    public class DataContext : DbContext
    {
        public DbSet<dentist> Dentists { get; set; }
        public DbSet<patient> Patients { get; set; }
        public DbSet<turn> Turn { get; set; }
        

        //public DataContext()
        //{

        //Dentists = new List<dentist>
        //{
        //    new dentist{Name="john fox",Id=128856789,Phone_number=0527554288,Status="dentist",Email="nbjks@gmail.com",Salary=3000},
        //    new dentist{Name="harry gong",Id=128999789,Phone_number=0563554288,Status="doctor",Email="bnjks@gmail.com",Salary=6000},
        //    new dentist{Name="dan vec",Id=128888789,Phone_number=0577554288,Status="doctor",Email="nbjnms@gmail.com",Salary=4000}
        //};
        //Patients = new List<patient>
        //{
        //    new patient{Name="sarit gruzman",Id=123456789,Phone_number=0527644288,Status="adult",Email="nbjks@gmail.com",Address="desler 10,bnei brak"},
        //    new patient{Name="noa amir",Id=987654321,Phone_number=0548423265,Status="adult",Email="kjjbvsdk@gmail.com",Address="ben kuk,bnei brak"},
        //    new patient{Name="ron popes",Id=215182932,Phone_number=0522244765,Status="child",Email="NULL",Address="YUTA 20,ramat gan"},
        //    new patient{Name="peter dan",Id=123454321,Phone_number=0583270079,Status="adult",Email="hfdb6464@gmail.com",Address="yosei 19,bnei brak"}
        //};
        //Turn = new List<turn>
        //{
        //    new turn{ Date="31.1.25",TurnNum=56,Time="5:30",Type="braces",DurantionOfTreatment=45,DoctorName="john fox"},
        //    new turn{ Date="12.2.25",TurnNum=98,Time="15:40",Type="root canal",DurantionOfTreatment=60,DoctorName="john fox"},
        //    new turn{ Date="08.8.25",TurnNum=86,Time="18:00",Type="crown",DurantionOfTreatment=25,DoctorName="harry gong"},
        //    new turn{ Date="26.9.25",TurnNum=23,Time="8:30",Type="teeth cleaning",DurantionOfTreatment=15,DoctorName="dan vec"},
        //    new turn{ Date="13.1.25",TurnNum=54,Time="12:20",Type="dentures",DurantionOfTreatment=30,DoctorName="harry gong"}
        //};
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=DentalClinic_db");
            //optionsBuilder.LogTo(m => Console.WriteLine(m));
        }




    }
}
