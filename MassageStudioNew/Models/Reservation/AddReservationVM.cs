using MassageStudioApp.Models.Category;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MassageStudioApp.Models.Reservation
{
    public class AddReservationVM
    { 
        [Key]
        public int Id { get; set; }
        public int HourId { get; set; }
        public int CategoryId { get; set; }
        public virtual List<CategoryPairVM> Categories { get; set; }
    }
}
