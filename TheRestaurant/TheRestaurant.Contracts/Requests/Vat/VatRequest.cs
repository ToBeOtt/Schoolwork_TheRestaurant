using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheRestaurant.Contracts.Requests.Vat
{
    public record VatRequest(
        string Name,
        double Adjustment
        );

}
