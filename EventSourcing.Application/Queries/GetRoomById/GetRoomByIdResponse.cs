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
        public  string Name { get; set; }
        public  string Description { get; set; }
        public  string City { get; set; }
        public  string Street { get; set; }
        public  string HouseNumber { get; set; }
        public  string ApartamentNumber { get; set; }
        public  string PostCode { get; set; }
        public List<ReservationDto> Reservations { get; set; }
        public List<Opinion> Opinions { get; set; }
        public string RoomStream { get; set; }
        public bool IsSuccess {  get; set; } 
    }

   
}
