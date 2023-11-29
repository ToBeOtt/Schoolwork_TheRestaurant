using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheRestaurant.Contracts.DTOs
{
    public class AllergyDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
