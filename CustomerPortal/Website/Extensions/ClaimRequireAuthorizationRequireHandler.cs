using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Extensions
{
    public class ClaimRequireAuthorizationRequireHandler : AuthorizationHandler<ClaimAuthorizationRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ClaimAuthorizationRequirement requirement)
        {
            if (context.User != null)
            {
                var matchingClaims =
                    context.User.Claims.Any(c => string.Equals(c.Type, requirement.ClaimType, StringComparison.OrdinalIgnoreCase)
                                            && string.Equals(c.Value, requirement.ClaimValue, StringComparison.Ordinal));

                if (matchingClaims)
                {
                    context.Succeed(requirement);
                }
            }

            return Task.FromResult(0);
        }
    }
}
