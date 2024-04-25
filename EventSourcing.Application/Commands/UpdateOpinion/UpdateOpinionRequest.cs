﻿using MediatR;

namespace EventSourcing.Application.Commands.UpdateOpinion
{
    public class UpdateOpinionRequest : IRequest<UpdateOpinionResponse>
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Text { get; set; }
        public int RoomId { get; set; }

    }
}
