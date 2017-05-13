using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Website.Models;

namespace Website.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Company> Companies { get; set; }

        public DbSet<CompanyClaims> CompanyClaims { get; set; }


        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>(au =>
            {
                au.HasOne(c => c.MyCompany).WithMany(cu => cu.Users).HasForeignKey(ccu => ccu.CompanyId).IsRequired();
            });

            builder.Entity<Company>(c =>
            {
                c.HasIndex(u => u.CreatedTime).HasName("CreationTimeIndex");
                c.Property(u => u.CreatedTime).HasDefaultValueSql("getdate()");
                c.HasMany(au => au.Users).WithOne(auc => auc.MyCompany).HasForeignKey(aucc => aucc.CompanyId).IsRequired();
                c.HasMany(au => au.Claims).WithOne(auc => auc.Company).HasForeignKey(aucc => aucc.CompanyId).IsRequired();
            });

            builder.Entity<CompanyClaims>(cc =>
            {
                cc.HasOne(ccc => ccc.Company).WithMany(cccc => cccc.Claims).HasForeignKey(aucc => aucc.CompanyId).IsRequired();
            });
            //b.HasMany(r => r.Users).WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();
        }
    }
}
