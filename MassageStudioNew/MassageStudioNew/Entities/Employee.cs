using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MassageStudioApp.Entities
{
    public class Employee
    {
        public Employee()
        {
            this.Hours = new HashSet<Hour>();
            this.Massages = new HashSet<Massage>();
        }
        
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(10)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(30)]
        public string JobTitle { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Hour> Hours { get; set; }
        public virtual ICollection<Massage> Massages { get; set; }
    }
}
