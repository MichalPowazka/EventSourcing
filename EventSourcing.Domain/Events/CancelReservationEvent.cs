using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventSourcing.Domain.Entities;

namespace EventSourcing.Domain.Events
{
    public class CancelReservationEvent : ReservationEvent
    {
        public User User { get; set; }
        public string CancelReason { get; set; }
    }
}
