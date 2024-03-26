using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Application.Commands.UpdateReservation
{
    public class UpdateReservationResponse
    {
        public bool IsSuccess {  get; set; }
        public string Message { get; set; }
    }
}
