using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Northwind.Core.Entities.Identity;

namespace Northwind.Infrastructure.Data.Configurations.Identity
{
    public static class IdentityConfiguration
    {
        public static ModelBuilder ApplyNorthwindIdentityConfiguration(this ModelBuilder builder)
        {
            builder.Entity<NorthwindUser>().ToTable("Users", "security");
            builder.Entity<IdentityRole>().ToTable("Roles", "security");
            builder.Entity<IdentityUserRole<string>>()
                .ToTable("UserRoles", "security")
                .HasKey(x => new { x.UserId, x.RoleId });
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "security");
            builder.Entity<IdentityUserLogin<string>>()
                .ToTable("UserLogins", "security")
                .HasNoKey();
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "security");
            builder.Entity<IdentityUserToken<string>>()
                .ToTable("UserTokens", "security")
                .HasNoKey();

            return builder;
        }
    }
}
