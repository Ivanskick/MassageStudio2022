using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MassageStudioApp.Models.Reservation
{
    public class AllReservationsVM
    {
        [Key]
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public string ClientFullName { get; set; }

        public DateTime HourStart { get; set; }
        
        public string EmployeeFullName { get; set; }
    }
}
