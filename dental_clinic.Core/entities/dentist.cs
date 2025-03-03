using dental_clinic.Core.entities;
using System.ComponentModel.DataAnnotations;

namespace dental_clinic.entities
{
    public class dentist
    {

        public string Name { get; set; }
        [Key]
        public string Id { get; set; }
        public int Phone_number { get; set; }

        public string Status { get; set; }

        public string Email { get; set; }

        public int Salary { get; set; }
        public string Identity { get; set; }
        public ICollection<turn> turns { get; set; }
        public string UserId {  get; set; }
        public User user { get; set; }
        
    }
}
