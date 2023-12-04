using System.ComponentModel.DataAnnotations;

namespace TheRestaurant.Presentation.Shared.DTO.Authentication
{
    public class LoginDto
    {

        [EmailAddress(ErrorMessage = "Felaktig email-address")]
        [Required(ErrorMessage = "Mail-address måste fyllas i")]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
