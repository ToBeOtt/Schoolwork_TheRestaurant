using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheRestaurant.Contracts.Responses.Orders
{
    public record PendingOrdersResponse( int OrderNr,
        DateTime DateTimeOfOrder,
        List<ProductAndQuantity> ProductAndQuantity,
        string? EmployeeName
        );
    
}
