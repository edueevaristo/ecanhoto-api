using Microsoft.AspNetCore.Http;
using ecanhoto.Model;

namespace ecanhoto.Helpers
{
    public static class UserHelper
    {
        private static IHttpContextAccessor _httpContextAccessor;

        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public static User GetCurrentUser()
        {
            return _httpContextAccessor.HttpContext.Items["User"] as User;
        }

        public static int? GetCurrentEmpresaId()
        {
            var user = GetCurrentUser();
            return user?.EmpresaId;
        }
    }
}
