using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheRestaurant.Application.DTOs
{
    public class OrderDTO
    {
        // Include only the properties you want to set via the form
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        // ... other properties like product details, quantity, etc.
    }
}

