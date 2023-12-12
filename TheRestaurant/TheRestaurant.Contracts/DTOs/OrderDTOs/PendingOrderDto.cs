using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRestaurant.Contracts.Responses.Orders;

namespace TheRestaurant.Contracts.DTOs.OrderDTOs
{
    public record PendingOrderDto(
       int OrderNr,
       DateTime DateTimeOfOrder,
       List<ProductAndQuantity> ProductAndQuantity,
       string EmployeeName
       );

    public record ProductAndQuantity(
       string ProductName,
       int Quantity);

   
}

