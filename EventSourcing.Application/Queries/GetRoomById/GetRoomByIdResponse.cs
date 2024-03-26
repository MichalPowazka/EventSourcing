using EventSourcing.Application.Dto;
using EventSourcing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Application.Queries.GetRoomById
{
    public class GetRoomByIdResponse
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string City { get; set; }
        public required string Street { get; set; }
        public required string HouseNumber { get; set; }
        public required string ApartamentNumber { get; set; }
        public required string PostCode { get; set; }
        public List<ReservationDto> Reservations { get; set; }
        public List<Opinion> Opinions { get; set; }
        public string RoomStream { get; set; }
    }
}
