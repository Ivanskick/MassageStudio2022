using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MassageStudioApp.Entities
{
    public class Massage
    {

        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }

        [Required]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
