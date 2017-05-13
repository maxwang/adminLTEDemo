using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Extensions
{
    public class ClaimAuthorizationRequirement : IAuthorizationRequirement
    {
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
}
