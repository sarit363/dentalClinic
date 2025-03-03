using System.ComponentModel.DataAnnotations;

namespace dental_clinic.Models
{
    public class dentistPostModels
    {
        public string Name { get; set; }
        public int Phone_number { get; set; }

        public string Status { get; set; }

        public string Email { get; set; }

        public int Salary { get; set; }
        public string Identity { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
