using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Domain.Events
{
    public class ReservationEvent
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }

    }
}
