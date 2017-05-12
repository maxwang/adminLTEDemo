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


        public DbSet<CompanyUser> CompanyUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<Company>(c =>
            {
                c.HasIndex(u => u.CreatedTime).HasName("CreationTimeIndex");
                c.Property(u => u.CreatedTime).HasDefaultValueSql("getdate()");
                //c.HasMany(cc => cc.Claims).WithOne().HasForeignKey(ccc => ccc.ComapnayId).IsRequired();
            });

            builder.Entity<CompanyClaims>(cc =>
            {

            });
            //b.HasMany(r => r.Users).WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();
        }
    }
}
