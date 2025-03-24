using System;
using GroceryStore.Backend.DAL.Entities;
using GroceryStore.Backend.DAL.IdentityUserExtend;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GroceryStore.Backend.DAL.Data.DbContext
{
	public class GroceryDbContext : IdentityDbContext<ApplicationUser>
	{
		public GroceryDbContext(DbContextOptions<GroceryDbContext> options) : base(options)
		{
		}

        public DbSet<ProductEntity> ProductTable { get; set; }

        public DbSet<CategoryEntity> CategoryTable { get; set; }

        public DbSet<CartEntity> CartTable { get; set; }

        public DbSet<OrderEntity> OrderTable { get; set; }

        public DbSet<ReviewEntity> ReviewTable { get; set; }

        // While craetion of model we need to create some admin users to edit and add product 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = "Admin" });

            var hasher = new PasswordHasher<IdentityUser>();

            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                    UserName = "abhishek@gmail.com",
                    NormalizedUserName = "ABHISHEK@GMAIL.COM",
                    PhoneNumber = "9157806213",
                    Email = "abhishek@gmail.com",
                    NormalizedEmail = "ABHISHEK@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "@Ab123456"),
                    FullName = "Abhishek Pandey",
                    IsAdmin = true
                },
                new ApplicationUser
                {
                    Id = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                    UserName = "myadmin@gmail.com",
                    NormalizedUserName = "MYADMIN@GMAIL.COM",
                    PhoneNumber = "0123456789",
                    Email = "myadmin@gmail.com",
                    NormalizedEmail = "MYADMIN@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "@Ad123456"),
                    FullName = "Admin Nagarro",
                    IsAdmin = true
                }
            );

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "1",
                    UserId = "b74ddd14-6340-4840-95c2-db12554843e5"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "1",
                    UserId = "2c5e174e-3b0e-446f-86af-483d56fd7210"
                }
            );
        }
    }
}

