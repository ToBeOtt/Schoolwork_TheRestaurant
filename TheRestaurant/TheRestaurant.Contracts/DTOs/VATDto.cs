using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheRestaurant.Contracts.DTOs
{
    public class VATDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ange namn för momsen")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Ange % för momsen")]
        [Range(1.01, 1.5, ErrorMessage ="Värdet måste vara mellan 1 och 1.5")]
        public double Adjustment { get; set; }
    }
}
