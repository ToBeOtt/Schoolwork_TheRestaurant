using TheRestaurant.Domain.Entities.Authentication;

namespace TheRestaurant.Authentication.Services.AuthenticationServices.DTO
{
    public class AuthenticationDTO
    {
        public record ProvideJwtTokenDTO(
            Employee AppUser,
            string Token);

    }
}
