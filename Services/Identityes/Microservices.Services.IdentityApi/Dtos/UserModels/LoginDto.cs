using Microservices.Services.IdentityApi.Dtos.BaseModels;

namespace Microservices.Services.IdentityApi.Dtos.UserModels
{
    public class LoginDto:BaseDto
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
