﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Application.Commands.AddOpinion
{
    public class AddOpinionRequest : IRequest<AddOpinionResponse>
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public int RoomId { get; set; }
    }
}
