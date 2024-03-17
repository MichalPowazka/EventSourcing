using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventSourcing.Domain.Entities
{
    public class BookingDbContext(DbContextOptions options) : IdentityDbContext<User, Role,int>(options)
                 
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomToReservation> RoomToReservation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Dodaj inicjalizację użytkowników i ról
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<User>();

            // Dodaj role
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
                new Role { Id = 2, Name = "User", NormalizedName = "USER" }
            // Dodaj więcej ról, jeśli chcesz
            );

            // Dodaj użytkowników
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 99,
                    UserName = "admin@example.com",
                    NormalizedUserName = "ADMIN@EXAMPLE.COM",
                    Email = "admin@example.com",
                    NormalizedEmail = "ADMIN@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Admin123$"), // Haszowanie hasła,
                    StreamId = new Guid().ToString(),
                }
            // Dodaj więcej użytkowników, jeśli chcesz
            );

            // Dodaj przypisanie ról do użytkowników
  modelBuilder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int> { UserId = 99, RoleId = 1 }// P
                                                                            // Dodaj więcej przypisań ról do użytkowników, jeśli chcesz
            );
        }
    }

}

   

