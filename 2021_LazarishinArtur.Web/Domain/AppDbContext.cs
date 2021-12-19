using _2021_LazarishinArtur.Web.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _2021_LazarishinArtur.Web.Domain
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<HeatLossCircleData> HeatLossCircleDatas { get; set; }
        public DbSet<HeatLossRectangleData> HeatLossRectangleDatas { get; set; }
        public DbSet<HeatLossSquaredData> HeatLossSquaredDatas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "885cc833-3b2c-47bb-9b90-b8439f506d2a",
                Name= "admin",
                NormalizedName = "ADMIN"
            });

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "364e4d9d-9ba6-4dd8-b1eb-07d7c58061a0",
                Name = "user",
                NormalizedName = "USER"
            });

            builder.Entity<User>().HasData(new User
            {
                Id = "885cc833-3b2c-47bb-9b90-b8439f506d2a",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email ="art@mail.ru",
                NormalizedEmail = "ART@MAIL.RU",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<User>().HashPassword(null, "admin"),
                SecurityStamp=string.Empty
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "885cc833-3b2c-47bb-9b90-b8439f506d2a",
                UserId = "885cc833-3b2c-47bb-9b90-b8439f506d2a"
            });

        }
    }
}
