using Microsoft.Extensions.Options;
using ecanhoto.Model;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using ecanhoto.Services;


namespace ecanhoto.Helpers

{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }
        
        // Este método recupera o token no header da requisição 
        public async Task Invoke(HttpContext context, UserService userService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                await this.attachUserToContext(context, userService, token);

            await _next(context);


        }         

        // Este método tenta validar o Token da requisição de acordo com o secret definido em appSettings
        // Se a validação funcionar, recuperamos os dados do usuário e interceptamos o Http Request incrementando os dados do usuário.
        private async Task attachUserToContext(HttpContext context, UserService userService, string token)
        {   
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);


                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // define para que os token expirem exatamente no tempo expiração, ao invés de 5 minutos depois.
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                context.Items["User"] = await userService.GetById(userId);

            }
            catch
            {
                // não faz nada se a autenticação Jwt falhar
            }
        }

    }
}
