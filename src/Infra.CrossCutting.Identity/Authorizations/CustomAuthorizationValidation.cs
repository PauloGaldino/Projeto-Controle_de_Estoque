using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace Infra.CrossCutting.Identity.Authorizations
{
    public static class CustomAuthorizationValidation
    {
        public static bool UserHasValidClaim(HttpContext context, string claimName, string claimValue)
        {
            return context.User.Identity.IsAuthenticated &&
                context.User.Claims.Any(c => c.Type == claimName && c.Value.Split('.').Contains(claimValue));
        }
    }
}
