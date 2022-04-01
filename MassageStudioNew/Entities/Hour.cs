using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MassageStudioApp.Entities
{
    public class Hour
    {
        [Key]
        public int Id { get; set; }

        public DateTime FreeHour { get; set; }

        public bool IsDeleted { get; set; } = false;

        public bool IsBusy { 
            get
            {
                return ReservationId > 0;
            }}

        [Required]
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

        [ForeignKey("Reservation")]
        public int? ReservationId { get; set; }

        public virtual Reservation Reservation { get; set; }
    }
}

