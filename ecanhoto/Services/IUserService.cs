using ecanhoto.Model;
using ecanhoto.DTO;

namespace ecanhoto.Services
{
  
    public interface IUserService
    {
        Task<AuthenticateResponse?> Authenticate(AuthenticateRequest authRequest);
        Task<IEnumerable<User>> GetAll(bool? isActive);
        Task<User?> GetById(int id);

        Task<User?> Create(CreateOrUpdateUserRequest request);

        Task<User?> Update(CreateOrUpdateUserRequest request);
    }

    
}
