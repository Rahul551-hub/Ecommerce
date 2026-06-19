using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data
{
    public class EcommerceDataContent : DbContext
    {
        public EcommerceDataContent(DbContextOptions option1):base(option1) 
        {
            
        }

        public DbSet<User> UserDetails { get; set; }
        public DbSet<Role> RoleDetails { get; set; }
        public DbSet<UserRole> UserRoleDetails { get; set; }

        //here we RE TRYING TO CONTROL THE EXPLECIT RELATIONS THOSE ARE GOING TO CREATED BY THE EFCORE
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>().HasKey(x => new { x.RoleId,x.UserId });

            modelBuilder.Entity<UserRole>()
                .HasOne(my => my.user)
                .WithMany(u => u.UserRoles) 
                .HasForeignKey(my => my.UserId);
             
            modelBuilder.Entity<UserRole>()
              .HasOne(my => my.Role)
              .WithMany(u => u.UserRoles)
              .HasForeignKey(my => my.RoleId);
        }


    }
}
