using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MassageStudioApp.Models.Hour
{
    public class HourPairVM
    {
        [Key]
        public int HourId { get; set; }
        public string HourInfo { get; set; }
    }
}
