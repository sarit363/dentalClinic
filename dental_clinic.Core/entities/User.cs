using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dental_clinic.Core.entities
{
    public class User
    {
        [Key]
        public string Id { get; set; } 

        public string UserName { get; set; }
        public string Password { get; set; }
        public eRole Role { get; set; }
    }
    public enum eRole
    {
        secretary, dentist, patient
    }
}
