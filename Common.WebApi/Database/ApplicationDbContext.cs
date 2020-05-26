using System;
using Common.WebApi.Database.Entities;
using Common.WebApi.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Common.WebApi.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserEntity> UserEntities { get; set; }
        public DbSet<RoleEntity> RoleEntities { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity()
                {
                    Id = 1,
                    FirstName = "Robert",
                    LastName = "Lara",
                    Password = Cryptography.HashPassword("Password123."),
                    Username = "rlara",
                    RoleId = 1
                },
                new UserEntity()
                {
                    Id = 2,
                    FirstName = "John",
                    LastName = "Doe",
                    Password = Cryptography.HashPassword("PasswordABC."),
                    Username = "jdoe",
                    RoleId = 2
                }
                );

            modelBuilder.Entity<RoleEntity>().HasData(
                new RoleEntity()
                {
                    Id = 1,
                    Name = "Administrator"
                },
                new RoleEntity()
                {
                    Id = 2,
                    Name = "Client"
                }
                );
        }

    }
}
