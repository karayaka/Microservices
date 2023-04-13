using Microservices.Services.IdentityApi.Dtos.BaseModels;

namespace Microservices.Services.IdentityApi.Dtos.SecurityModels
{
    public class LoginResponseDTO:BaseDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Token { get; set; }

        public DateTime ExpireDate { get; set; }
    }
}
