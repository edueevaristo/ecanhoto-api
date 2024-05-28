using ecanhoto.Context;
using ecanhoto.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ecanhoto.DTO;

namespace ecanhoto.Services
{   
    public class UserService: IUserService
    {

        private readonly AppSettings _appSettings;
        private readonly DataContext _dataContext;

        public UserService(IOptions<AppSettings> appSettings, DataContext _dataContext)
        {
            _appSettings = appSettings.Value;
            _dataContext = _dataContext;
        }

        public async Task<AuthenticateResponse?> Authenticate(AuthenticateRequest authRequest)
        {
            var user = _dataContext.Users.SingleOrDefaultAsync(x => x.Username == authRequest.Username && x.Password == authRequest.Password);

            if (user == null) return null;

            var token = await generateJwtToken(user.Result);

            return new AuthenticateResponse(user.Result, token);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _dataContext.Users.Where(x => x.isActive == true).ToListAsync();
        }

        public async Task<User?> GetById(int id)
        {
            return await _dataContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User?> AddAndUpdateUser(User userObj)
        {
            bool isSuccess = false;

            // Se o Id existe, atualiza
            if(userObj.Id > 0)
            {
                var obj = await _dataContext.Users.FirstOrDefaultAsync(c => c.Id == userObj.Id);

                if (obj != null) 
                {
                    obj.FirstName = userObj.FirstName;
                    obj.LastName = userObj.LastName;
                    _dataContext.Users.Update(obj);

                    isSuccess = await _dataContext.SaveChangesAsync() > 0;
                }
            }
            else
            {
                await _dataContext.Users.AddAsync(userObj);
                isSuccess = await _dataContext.SaveChangesAsync() > 0;
            }

            return isSuccess ? userObj : null;
        }



        private async Task<string> generateJwtToken(User user)
        {
            // Gera um token que é válido por 7 dias
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = await Task.Run(() =>
            {
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                return tokenHandler.CreateToken(tokenDescriptor);

            });

            return tokenHandler.WriteToken(token);

        }
    }
}
