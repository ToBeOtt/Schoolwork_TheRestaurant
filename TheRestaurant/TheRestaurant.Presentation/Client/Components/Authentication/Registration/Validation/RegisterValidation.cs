using System.ComponentModel.DataAnnotations;

namespace TheRestaurant.Presentation.Client.Components.Authentication.Registration.Validation
{
    public class RegisterValidation
    {
        [Required(ErrorMessage = "Användarnamn måste fyllas i")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email-address måste fyllas i")]
        [EmailAddress(ErrorMessage = "Felaktig email-address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lösenord är nödvändigt")]
        [MinLength(8, ErrorMessage = "Lösenordet behöver innehålla minst 8 tecken.")]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Lösenorden matchar inte")]
        public string RepeatPassword { get; set; }
    }
}