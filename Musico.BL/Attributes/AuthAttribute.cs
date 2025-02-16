using Microsoft.AspNetCore.Mvc.Filters;
using Musico.BL.Constants;
using Musico.BL.Exceptions.UserExceptions;
using Musico.Core.Entities;
using System.ComponentModel;

namespace Musico.BL.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthAttribute : Attribute, IAsyncActionFilter
    {
        private int access;
        public AuthAttribute(Roles role)
        {
            access = (int)role;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var value = context.HttpContext.User.FindFirst(x => x.Type == ClaimType.Role)?.Value;
            if (value == null)
                throw new AuthorizationException();
            int role = Convert.ToInt32(value);
            if ((role & access) != access)
                throw new UserHasNoPermissionException();
            await next();
        }
    }
}
