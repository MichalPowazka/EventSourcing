using EventSourcing.Application.Commands.AddBooking;
using EventSourcing.Application.Commands.CancelReservation;
using EventSourcing.Application.Commands.UpdateReservation;
using EventSourcing.Application.Queries.CheckAvailability;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventSourcingApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]

    public class ReseravationContoller(IMediator _mediator) : ControllerBase
    {

        
        //query//Pobranie rezerwacji // pobranie eventów per pokoj
        //Lista rezerwacji // wszytkich lub po jakims filtrze
        // query //Historia rezerwacji
      
      


        //logowanie
        //rejestracja
        //


        [HttpPost]
        public async Task<ActionResult<int>> AddReservation(AddBookingRequest request)
        {
            var result = await _mediator.Send(request);
            //var a = await test.GetById(request.Id).ToListAsync();
            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult<int>> CancelReservation(CancelReservationRequest request)
        {
            var result = await _mediator.Send(request);
            //var a = await test.GetById(request.Id).ToListAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> UpdateReservation(UpdateReservationRequest request)
        {
            var result = await _mediator.Send(request);
            //var a = await test.GetById(request.Id).ToListAsync();
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> CheckAvailability([FromQuery] CheckAvailabilityQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
