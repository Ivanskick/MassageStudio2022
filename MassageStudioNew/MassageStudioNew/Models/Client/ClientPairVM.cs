using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MassageStudioApp.Models.Client
{
    public class ClientPairVM
    {
        [Key]
        public int ClientId { get; set; }
        public string FullName { get; set; }
    }
}
