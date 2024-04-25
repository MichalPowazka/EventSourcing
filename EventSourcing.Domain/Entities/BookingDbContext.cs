using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventSourcing.Domain.Entities;

public class BookingDbContext(DbContextOptions options) : IdentityDbContext<User, Role, int>(options)

{
    public DbSet<Room> Rooms { get; set; }
    public DbSet<RoomImage> RoomImages { get; set; }
    public DbSet<Opinion> Opinion { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        SeedData(modelBuilder);
    }
    private static void SeedData(ModelBuilder modelBuilder)
    {
        var hasher = new PasswordHasher<User>();


        modelBuilder.Entity<Role>().HasData(
            new Role { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
            new Role { Id = 2, Name = "User", NormalizedName = "USER" }
        );
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 99,
                UserName = "admin@example.com",
                NormalizedUserName = "ADMIN@EXAMPLE.COM",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Admin123$"),
                StreamId = new Guid().ToString(),
            }
        );
        modelBuilder.Entity<IdentityUserRole<int>>().HasData(
        new IdentityUserRole<int> { UserId = 99, RoleId = 1 }
    );

        modelBuilder.Entity<IdentityUserRole<int>>().HasData(
        new IdentityUserRole<int> { UserId = 99, RoleId = 2 }
        );
    }
}



