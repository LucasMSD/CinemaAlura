using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UsuariosApi.Models;

namespace UsuariosApi.Data
{
    public class UserDbContext : IdentityDbContext<CustomIdentityUser, IdentityRole<int>, int>
    {
        IConfiguration _config;

        public UserDbContext(DbContextOptions<UserDbContext> opt, IConfiguration config) : base(opt)
        {
            _config = config;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var admin = new CustomIdentityUser
            {
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                Id = 99999
            };

            var hasher = new PasswordHasher<CustomIdentityUser>();

            admin.PasswordHash = hasher.HashPassword(admin, _config.GetValue<string>("AdminInfo:Password"));


            builder.Entity<CustomIdentityUser>().HasData(admin);

            builder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int>
            {
                Id = 99999,
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            builder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int>
            {
                Id = 99998,
                Name = "regular",
                NormalizedName = "REGULAR"
            });

            builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>
            {
                RoleId = 99999,
                UserId = 99999
            });




        }
    }
}
