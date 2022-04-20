using MassageStudioApp.Models.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MassageStudioApp.Models.Hour
{
    public class EditHourVM
    {
        public EditHourVM()
        {
            Employees = new List<EmployeePairVM>();
        }

        [Key]
        public int Id { get; set; }
        public DateTime FreeHour { get; set; }

        [Required]
        [DisplayName("Employee")]
        public int EmployeeId { get; set; }

        public virtual List<EmployeePairVM> Employees { get; set; }
    }
}
