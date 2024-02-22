using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Domain.Entities
{
    public class BookingDbContext: IdentityUserContext<User, int, IdentityUserClaim<int>,
                 IdentityUserLogin<int>,IdentityUserToken<int>>
                 
    {
        
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomToReservation> RoomToReservation { get; set; }

        public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options)
        {

        }

    }

   
}
