using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Website.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Website.Data;

namespace Website.Extensions
{
    public class SMSUserStore<TUser> : UserStore<TUser>
        where TUser : ApplicationUser, new()
    {
        public SMSUserStore(ApplicationDbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
        {
            
        }
        
        public Company GetCompany(int companyId)
        {
            var aContext = Context as ApplicationDbContext;
            return aContext.Companies.FirstOrDefault(x => x.Id == companyId);
        }

        public async Task<Company> GetCompanyAsync(int companyId)
        {
            var aContext = Context as ApplicationDbContext;
            return await aContext.Companies.FirstOrDefaultAsync(x => x.Id == companyId);
        }

        public IEnumerable<CompanyClaims> GetCompanyClaims(int companyId)
        {
            var aContext = Context as ApplicationDbContext;
            return aContext.CompanyClaims.Where(x => x.CompanyId == companyId).ToList();
        }

        public async Task<IEnumerable<CompanyClaims>> GetCompanyClaimsAsync(int companyId)
        {
            var aContext = Context as ApplicationDbContext;
            return await aContext.CompanyClaims.Where(x => x.CompanyId == companyId).ToListAsync();
        }
    }
}
