using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MassageStudioApp.Models.Category
{
    public class CreateCategoryVM
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }


        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        [Range(0.01, 1000.00)]
        public decimal Price { get; set; }
    }
}
