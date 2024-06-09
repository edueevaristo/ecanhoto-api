using ecanhoto.Context;
using ecanhoto.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ecanhoto.DTO;
using ecanhoto.Services;
using System.Reflection.Metadata.Ecma335;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using ecanhoto.Helpers;

namespace ecanhoto.Services
{   
    public class UserService : IUserService
    {

        private readonly AppSettings _appSettings;
        private readonly DataContext _dataContext;

        public UserService(IOptions<AppSettings> appSettings, DataContext dataContext)
        {
            _appSettings = appSettings.Value;
            _dataContext = dataContext;
        }

        public async Task<AuthenticateResponse?> Authenticate(AuthenticateRequest authRequest)
        {
            var user = _dataContext.Users.FirstOrDefaultAsync(x => x.Email == authRequest.Email && x.Password == authRequest.Password);

            if (user.Result == null)
            {
                return null;
            }
                

            var token = await generateJwtToken(user.Result);

   
            return new AuthenticateResponse(user.Result, token);
        }

        
        public async Task<IEnumerable<User>> GetAll(bool? isActive)
        {
            User? currentUser = UserHelper.GetCurrentUser();

            if (currentUser == null)
            {
                // Se o usuário não estiver logado, retornar uma lista vazia 
                return new List<User>();
            }

            if (isActive.HasValue)
            {
                return await _dataContext.Users.Where(user => user.IsActive == isActive && user.EmpresaId == currentUser.EmpresaId).ToListAsync();
            }

            return await _dataContext.Users.Where(user => user.IsActive == true && user.EmpresaId == currentUser.EmpresaId).ToListAsync();

        }

        public async Task<User?> GetById(int id)
        {
            return await _dataContext.Users.FirstOrDefaultAsync(user => user.Id == id);
        }


        public async Task<User?> Create(CreateOrUpdateUserRequest request)
        {
            User user = request.ToModel();

            await _dataContext.Users.AddAsync(user);

            return await _dataContext.SaveChangesAsync() > 0 ? user : null;

        }

        public async Task<User?> Update(CreateOrUpdateUserRequest request)
        {
            if(!request.Id.HasValue || request.Id.Value <= 0)
                return null; // Não é possível atualizar sem o ID do usuario na request

            // Procura Usuario pelo id

            User? user = await _dataContext.Users.FindAsync(request.Id.Value);

            if (user == null) return null;

            user.Name = request.Name;
            user.Email = request.Email;
            user.EmpresaId = request.EmpresaId;
            user.Password = request.Password; //hash a senha aqui
            user.IsActive = request.IsActive;

            _dataContext.Users.Update(user);

            return await _dataContext.SaveChangesAsync() > 0 ? user : null;

        }
        private async Task<string> generateJwtToken(User user)
        {
            // Gera um token que é válido por 7 dias
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = await Task.Run(() =>
            {
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

                if (key.Length < 32)
                {
                    throw new ArgumentException("A chave secreta deve ter pelo menos 16 caracteres.");
                }

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
