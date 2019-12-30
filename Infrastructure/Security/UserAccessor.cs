using System.Linq;
using System.Security.Claims;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Security
{
    public class UserAccessor : IUserAccessor
    {
        private readonly IHttpContextAccessor __httpContextAccessor;
        public UserAccessor(IHttpContextAccessor _httpContextAccessor)
        {
            __httpContextAccessor = _httpContextAccessor;
        }

        public string GetCurrentUsername()
        {
            var username = __httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            return username;
        }
    }
}