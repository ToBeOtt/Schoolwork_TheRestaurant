using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheRestaurant.Contracts.Requests.MenuItem
{
    public record EditMenuItemRequest(
        string Name,
        string Description,
        byte[] MenuPhoto
        );

}
