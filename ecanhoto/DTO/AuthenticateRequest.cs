using System.ComponentModel;
namespace ecanhoto.DTO
{
    public class AuthenticateRequest
    {
        [DefaultValue("system@system.com")]
        public required string Email { get; set; }

        [DefaultValue("System")]
        public required string Password { get; set; }

    }
}
