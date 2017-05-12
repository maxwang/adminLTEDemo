using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Website.Data;

namespace Website.Extensions
{
    public class SMSClaimsTransformer : IClaimsTransformer
    {
        protected readonly ApplicationDbContext db;

        public SMSClaimsTransformer()
        {
        }

        public SMSClaimsTransformer(ApplicationDbContext context)
        {
            db = context;
        }

        public Task<ClaimsPrincipal> TransformAsync(ClaimsTransformationContext context)
        {
            var identity = (ClaimsIdentity)context.Principal.Identity;

            if (context.Context.User != null)
            {
                var nameClaim = context.Context.User.FindFirst(ClaimTypes.NameIdentifier);
                if (nameClaim != null)
                {
                    var userId = nameClaim.Value;

                    var company = db.CompanyUsers.FirstOrDefault(x => x.UserId == userId);
                    if (company != null)
                    {
                        var companyClaims = db.CompanyClaims.Where(x => x.CompanyId == company.CompanyId);
                        foreach (var companyClaim in companyClaims)
                        {
                            if (!identity.HasClaim(companyClaim.ClaimType, companyClaim.ClaimValue))
                            {
                                identity.AddClaim(new Claim(companyClaim.ClaimType, companyClaim.ClaimValue));
                            }
                        }
                    }

                    var userClaims = db.UserClaims.Where(x => x.UserId == userId);
                    foreach (var claim in db.UserClaims)
                    {
                        if (!identity.HasClaim(claim.ClaimType, claim.ClaimValue))
                        {
                            identity.AddClaim(new Claim(claim.ClaimType, claim.ClaimValue));
                        }

                    }
                }
            }
            return Task.FromResult(context.Principal);
        }
    }
}
