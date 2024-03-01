using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventSourcing.Domain.Entities
{
    public class BookingDbContext(DbContextOptions options) : IdentityDbContext<User, Role,int>(options)
                 
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomToReservation> RoomToReservation { get; set; }

   

    }

   
}
