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
        [Required(ErrorMessage ="Namn måste anges.")]
        [MaxLength(30, ErrorMessage ="Max 30 tecken långt.")]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        


    }
}
