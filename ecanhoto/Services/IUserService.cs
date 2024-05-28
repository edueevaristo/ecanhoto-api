using ecanhoto.Model;
using ecanhoto.DTO;

namespace ecanhoto.Services
{
    public interface IUserService
    {
       public interface IUserService
       {
            Task<AuthenticateResponse?> Authenticate(AuthenticateRequest authRequest);
            Task<IEnumerable<User>> GetAll();
            Task<User?> GetById(int id);
            Task<User?> AddAndUpdateUser(User userObj);
       }

    }
}
