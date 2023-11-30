using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace TheRestaurant.Presentation.Client.Components.Authentication.Login.DTO
{
    public class LoginDto
    {

        [EmailAddress(ErrorMessage = "Felaktig email-address")]
        [Required(ErrorMessage = "Mail-address måste fyllas i")]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
