using System.ComponentModel.DataAnnotations.Schema;

namespace EventSourcing.Domain.Entities;

public class RoomImage
{
    public int Id { get; set; } 
    public int RoomId { get; set; }
    public string Name { get; set; }
    public string ImagePath { get; set; }

    [NotMapped]
    public string Image { get; set; }
}
