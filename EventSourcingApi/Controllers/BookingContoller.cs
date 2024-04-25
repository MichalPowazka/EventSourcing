using EventSourcing.Application.Commands.AddBooking;
using EventSourcing.Application.Commands.CancelReservation;
using EventSourcing.Application.Commands.UpdateReservation;
using EventSourcing.Application.Queries.CheckAvailability;
using EventSourcing.Application.Queries.GetReservation;
using EventSourcing.Application.Queries.GetReservationsAll;
using EventSourcing.Application.Queries.GetResevrationsLoggedUser;
using EventSourcingApi.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventSourcingApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]

    public class ReseravationController(IMediator _mediator) : Controller
    {

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
            var result = await _mediator.Send(request);
            return result;
        }

        [HttpPost]
        [RoleAuthorize("User")]
        public async Task<UpdateReservationResponse> UpdateReservation(UpdateReservationRequest request)
        {
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
        [RoleAuthorize("User","Admin")]
        public async Task<GetReservationResposne> GetReservationById([FromQuery] GetReservationRequest request)
        {
            var result = await _mediator.Send(request);
            return result;
        }

        [HttpGet]
        [RoleAuthorize("Admin")]
        public async Task<GetReservationsAllResponse> GetReservationsAll([FromQuery] GetReservationsAllQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return result;
        }

        [HttpGet]
        [RoleAuthorize("User")]
        public async Task<GetResevrationsLoggedUserResponse> GetReservationByUser([FromQuery] GetResevrationsLoggedUserQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return result;
        }



    }
}
