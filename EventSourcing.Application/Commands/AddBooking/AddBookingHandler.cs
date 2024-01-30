//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace EventSourcing.Application.Commands.AddBooking
//{
//    public class AddBookingHandler : IRequestHandler<AddBookingRequest, int>
//    {
//        public Task<int> Handle(AddBookingRequest request, CancellationToken cancellationToken)
//        {
//              var entity = new Booking()
//            {
//                // ustawienie pol z requesta
//            };
//            _bookingRepository.Add(entity);

//            //zapis eventa w Event store

//            return entity.Id;


//            throw new NotImplementedException();
//        }
//    }
//}
