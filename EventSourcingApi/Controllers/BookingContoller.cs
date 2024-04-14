using EventSourcing.Application.Commands.AddBooking;
using EventSourcing.Application.Commands.CancelReservation;
using EventSourcing.Application.Commands.UpdateReservation;
using EventSourcing.Application.Queries.CheckAvailability;
using EventSourcing.Application.Queries.GetReservation;
using EventSourcingApi.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventSourcingApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]

    public class ReseravationController(IMediator _mediator) : Controller
    {

        
        //query//Pobranie rezerwacji // pobranie eventów per pokoj
        //Lista rezerwacji // wszytkich lub po jakims filtrze
        // query //Historia rezerwacji
      
        [HttpPost]
        [RoleAuthorize("User")]
        public async Task<AddBookingResponse> AddReservation(AddBookingRequest request)
        {
            var result = await _mediator.Send(request);
            return result;
        }


        [HttpPost]
        [RoleAuthorize("User","Admin")]
        public async Task<CancelReservationResponse> CancelReservation(CancelReservationRequest request)
        {
            //sprawdzanie czy to jest twoja rezerwacja
            var result = await _mediator.Send(request);
            return result;
        }

        [HttpPost]
        public async Task<UpdateReservationResponse> UpdateReservation(UpdateReservationRequest request)
        {
            //sprawdzanie czy to jest twoja rezerwacja

            var result = await _mediator.Send(request);
            return result;
        }

        [HttpGet]
        public async Task<CheckAvailabilityResponse> CheckAvailability([FromQuery] CheckAvailabilityQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return result;
        }

        [HttpGet]
        public async Task<GetReservationResposne> GetReservationById([FromQuery] GetReservationRequest request)
        {
            var result = await _mediator.Send(request);
            return result;
        }

        

 

       

        //RezerwacjeByUser - zwraca twoje rezerwacje
        //admin dostep i mozliwosc anulowania lub zmiany czyjejsc rezerwacji
        //GetAllReservation dla admina
    }
}
