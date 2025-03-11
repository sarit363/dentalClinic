using dental_clinic.Core.entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dental_clinic.entities
{
    public class dentist
    {

        public string Name { get; set; }

        [Key]
        public string Id { get; set; }

        public string Phone_number { get; set; }
        public string Status { get; set; }
        public string Email { get; set; }
        public int Salary { get; set; }
        public string Identity { get; set; }
        public ICollection<turn> turns { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User user { get; set; }

    }
}
