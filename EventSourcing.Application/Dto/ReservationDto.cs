﻿using EventSourcing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Application.Dto
{
    public class ReservationDto
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string ReservationUniqueId { get; set; }
        public User User { get; set; }  
    }
}
