using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MassageStudioApp.Models.Hour
{
    public class AllHoursVM
    {
        public int Id { get; set; }
        public DateTime FreeHour { get; set; }

        public bool IsBusy { get; set; }

        public string EmployeeFullName { get; set; }
    }
}
