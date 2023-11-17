using TheRestaurant.Domain.Entities.Authentication;

namespace TheRestaurant.Authentication.Services.AuthenticationServices.DTO
{
    public class AuthenticationDTO
    {
        public record ProvideJwtTokenDTO(
            AppUser AppUser,
            string Token);

    }
}
