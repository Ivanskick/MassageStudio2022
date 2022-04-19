using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MassageStudioApp.Models.Hour
{
    public class HourDetailsVM
    {
        [Key]
        public int Id { get; set; }

        public DateTime FreeHour { get; set; }

        public bool IsDeleted { get; set; } = false;

        public bool IsBusy
        {
            get
            {
                return ReservationId > 0;
            }
        }

        public int EmployeeId { get; set; }

        [ForeignKey("Reservation")]
        public int? ReservationId { get; set; }
    }
}
