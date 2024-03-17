using EventSourcing.Application.Commands.AddBooking;
using EventSourcing.Domain.Entities;

namespace EventSourcing.Application.Services
{
    public interface IReseravtionService
    {
        Task<bool> IsAvaible(int roomId, DateTime dateFrom, DateTime dateTo);
        Task<bool> AddReservation(AddBookingRequest request, Room room);
    }
}