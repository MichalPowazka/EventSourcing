namespace EventSourcing.Domain.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string City { get; set; }
        public required string Street { get; set; }
        public required string HouseNumber { get; set; }
        public required string ApartamentNumber { get; set; }
        public required string PostCode { get; set; }
        public List<RoomToReservation> Reservations { get; set; }
        public List<Opinion> Opinions { get; set; }

    }
}
