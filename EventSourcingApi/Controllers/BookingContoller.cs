using EventSourcing.Application.Commands.AddBooking;
using EventSourcing.Domain;
using EventSourcing.Persistance.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace EventSourcingApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]

    public class BookingContoller(IMediator mediator , IReservationRepository test) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<int>> AddBooking(AddBookingRequest request)
        {
            await test.Save(new EventSourcing.Domain.Events.CreateReservationEvenet()
            {
                Id = 1,
                TimeStamp = DateTime.Now,
                DateFrom = DateTime.Now.AddDays(2),
                DateTo = DateTime.Now.AddDays(5),
                User = new Account()
            });

            await test.Save(new EventSourcing.Domain.Events.CancelReservationEvent()
            {
                Id = 1,
                TimeStamp = DateTime.Now,
                CancelReason = "tEST1",
                User = new Account()
            }); ; 
            //var res = await mediator.Send(request);


            return Ok(1);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventSourcing.Domain.Events.ReservationEvent>>> GetBooking()
        {
            //await test.Test();
            //var res = await mediator.Send(request);
            var res = await test.GetById(1).ToListAsync() ;

            return Ok(res);
        }
    }
}
