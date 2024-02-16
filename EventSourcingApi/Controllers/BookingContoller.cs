using EventSourcing.Application.Commands.AddBooking;
using EventSourcing.Application.Commands.CancelReservation;
using EventSourcing.Domain;
using EventSourcing.Persistance.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventSourcingApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]

    public class ReseravationContoller(IMediator _mediator, IReservationRepository test) : ControllerBase
    {

        //Dodanie rezerwacj,
        //Anulowanie rezerwacji
        //query//Pobranie rezerwacji // pobranie eventów per pokoj
        //Lista rezerwacji // wszytkich lub po jakims filtrze
        // query //Historia rezerwacji
        //comand  //Update rezerwcji
        //query //Sprawdzenie dostepnosci // srpradzzamy czy
        //podana data nie nie miesci sie w zakresach eventów typu create reseration
        //--> pozniej rozszerzyc na zakres dat
        //--> zasegurowac najblizszy najbardziej zbliony wolny 


        //logowanie
        //rejestracja
        //


        [HttpPost]
        public async Task<ActionResult<int>> AddReservation(AddBookingRequest request)
        {
            var result = await _mediator.Send(request);
            var a = await test.GetById(request.Id).ToListAsync();
            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult<int>> CancelReservation(CancelReservationRequest request)
        {
            var result = await _mediator.Send(request);
            var a = await test.GetById(request.Id).ToListAsync();
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<object>>> GetBooking()
        {
            //await test.Test();
            //var res = await mediator.Send(request);
            var res = await test.GetById(1).ToListAsync();
            foreach (var a in res)
            {
                var x = a.GetType().Name;

            }
            var res2 = res.Select(x => (object)x).ToList();
            return Ok(res2);
        }
    }
}
