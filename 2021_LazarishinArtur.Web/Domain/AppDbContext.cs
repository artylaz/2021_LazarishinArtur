using _2021_LazarishinArtur.Web.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace _2021_LazarishinArtur.Web.Domain
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<HeatLossCircleData> HeatLossCircleDatas { get; set; }
        public DbSet<HeatLossRectangleData> HeatLossRectangleDatas { get; set; }
        public DbSet<HeatLossSquaredData> HeatLossSquaredDatas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            string adminRoleName = "admin";
            string userRoleName = "user";

            string adminEmail = "admin@mail.ru";
            string adminName = "admin";
            string adminPassword = "admin";

            
            Role adminRole = new Role { Id = 1, Name = adminRoleName };
            Role userRole = new Role { Id = 2, Name = userRoleName };

            User adminUser = new User { Id = 1, Name = adminName,  Email = adminEmail, Password = adminPassword, RoleId = adminRole.Id };

            builder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            builder.Entity<User>().HasData(new User[] { adminUser });


        }
    }
}
