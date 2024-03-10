using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Domain.Events.Reservations
{


    public class ReservationAggregate
    {


        public int Id { get; private set; }

        private List<ReservationEvent> Events = new List<ReservationEvent>();
        // LISTA EVENTRT

        //ApplyEvent(Event @event)

        //GetLaatEvent()

        // GetEvents()

        public ReservationAggregate(int id)
        {
            Id = id;
        }

        public void ApplyEvent(ReservationEvent reserviationEvent)
        {
            Events.Add(reserviationEvent);
        }

        public List<ReservationEvent> GetEvent()
        {
            return Events;
        }

        public ReservationEvent GetLastEvent()
        {
            return Events.LastOrDefault();
        }
    }
}
