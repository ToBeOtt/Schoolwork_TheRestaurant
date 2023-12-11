using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheRestaurant.Contracts.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vänligen ange name")]
        [MaxLength(20, ErrorMessage = "Tecken är mer än 20 långa.")]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
