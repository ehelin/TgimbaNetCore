using Shared.dto.api;

namespace Shared.dto.api
{
    public class RegistrationRequest
    {
        public LoginRequest Login { get; set; }
        public string EncodedEmail { get; set; }
    }
}
