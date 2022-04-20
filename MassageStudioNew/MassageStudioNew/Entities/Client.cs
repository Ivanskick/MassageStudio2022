using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MassageStudioApp.Entities
{
    public class Client
    {
        public Client()
        {
            this.Massages = new HashSet<Massage>();
            this.Reservations = new HashSet<Reservation>();
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
        public DateTime BirthDate { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Massage> Massages { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
