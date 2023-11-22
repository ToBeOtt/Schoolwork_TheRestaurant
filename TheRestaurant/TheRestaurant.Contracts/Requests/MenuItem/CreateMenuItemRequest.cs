using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheRestaurant.Contracts.Requests.MenuItem
{
    // Need to add Category and Allergy once those are implemented
    public record CreateMenuItemRequest(
        string Name,
        string Description,
        byte[] MenuPhoto
        );

}
