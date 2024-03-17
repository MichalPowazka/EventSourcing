using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Application.Commands.AddBooking;

public class AddBookingRequest : IRequest<int>
{
    public int RoomId { get; set; }
    public int Id { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public int ResevationCount { get; set; }
    public string ControlValue { get; set; }

}
