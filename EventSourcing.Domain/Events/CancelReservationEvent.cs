using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Domain.Events
{
    public class CancelReservationEvent : ReservationEvent
    {
        public Account User { get; set; }
        public string CancelReason { get; set; }
    }
}
