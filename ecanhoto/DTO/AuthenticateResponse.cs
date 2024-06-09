using ecanhoto.Model;

namespace ecanhoto.DTO
{
    public class AuthenticateResponse
    {
        //public int Id { get; set; }
        //public string Name { get; set; }
        //public string Email { get; set; }
        //public int EmpresaId { get; set; }
        public string Token { get; set; }

        public User User { get; set; }

        public AuthenticateResponse(User user, string token)
        {
            User = new User(user.Name,user.Email, user.EmpresaId, user.Password, user.IsActive, user.IsAdmin );
            Token = token;
        }
    }
}
