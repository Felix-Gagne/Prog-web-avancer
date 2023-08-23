using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using app_revision.Models;
using Microsoft.AspNetCore.Identity;

namespace app_revision.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            //Cat seed
            Chat c1 = new Chat
            {
                Id = 1,
                Name = "Beluga",
                ImageUrl = "https://i.pinimg.com/originals/59/54/b4/5954b408c66525ad932faa693a647e3f.jpg"
            };

            builder.Entity<Chat>().HasData(c1);


            //Role seed
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN",
                Id = "1"
            });


            //User seed
            var hasher = new PasswordHasher<IdentityUser>();

            IdentityUser admin = new IdentityUser
            {
                Id = "11111111-1111-1111-1111-111111111111",
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
                // La comparaison d'identity se fait avec les versions normalisés
                NormalizedEmail = "ADMIN@ADMIN.COM",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                // On encrypte le mot de passe
                PasswordHash = hasher.HashPassword(null, "Passw0rd!")
            };

            builder.Entity<IdentityUser>().HasData(admin);


            //Add admin role to user
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "1",
                UserId = "11111111-1111-1111-1111-111111111111"
            });
        }

        public DbSet<app_revision.Models.Chat>? Chat { get; set; }
    }
}