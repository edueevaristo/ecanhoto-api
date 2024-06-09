using ecanhoto.Model;

namespace ecanhoto.DTO
{
    public class AuthenticateResponse
    {
        public string Token { get; set; }

        public User User { get; set; }

        public AuthenticateResponse(User user, string token)
        {
            User = new User(user.Id, user.Name, user.Email, user.EmpresaId, user.Password, user.IsActive, user.IsAdmin);
            Token = token;
        }
    }
}
