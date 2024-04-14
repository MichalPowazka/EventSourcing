using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Domain.Entities
{
    public class RoomImage
    {
        public int Id { get; set; } 
        public int RoomId { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        
    }
}
