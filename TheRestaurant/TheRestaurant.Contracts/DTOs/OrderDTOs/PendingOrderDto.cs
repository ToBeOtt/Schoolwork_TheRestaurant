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
       string? Comment,
       DateTime DateTimeOfOrder,
       List<ProductAndQuantity> ProductAndQuantity,
       string EmployeeName
       );

    public record ProductAndQuantity(
       string ProductName,
       string? Size,
       int Quantity);

   
}

