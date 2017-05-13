using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Extensions
{
    /*still do not know how to use it*/
    /*Should use this one with IAuthorizationPolicyProvider */
    public class AuthorizeClaimAttribute : Attribute, IAsyncAuthorizationFilter, IAuthorizationFilter, IFilterFactory
    {
        //public IAuthorizationClaimProvider PolicyProvider { get; }
        public IEnumerable<IAuthorizeData> AuthorizeData { get; }
        private string ClaimType;
        private string ClaimValue;

        public AuthorizeClaimAttribute(IEnumerable<IAuthorizeData> authorizeData)
        {
            AuthorizeData = authorizeData ?? throw new ArgumentNullException(nameof(authorizeData));
        }

        public AuthorizeClaimAttribute(string claimType, string claimValue) : 
            this(new[] { new AuthorizeAttribute(claimType), new AuthorizeAttribute(claimValue) })
        {
            ClaimType = claimType;
            ClaimValue = claimValue;
        }
        public bool IsReusable => false;

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            //if (Policy != null || PolicyProvider != null)
            //{
            //    // The filter is fully constructed. Use the current instance to authorize.
            //    return this;
            //}

            //var policyProvider = serviceProvider.GetRequiredService<IAuthorizationPolicyProvider>();
            return AuthorizationApplicationModelProvider.GetFilter(serviceProvider as IAuthorizationPolicyProvider, AuthorizeData);
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var i = 0;
            i++;

        }

        public Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {

            return Task.FromResult(true);
        }
    }
}
