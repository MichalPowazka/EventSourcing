using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventSourcing.Domain.Entities;

namespace EventSourcing.Domain.Events.Reservations
{
    public class CreateReservationEvenet 
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public User User { get; set; }
    }
}
