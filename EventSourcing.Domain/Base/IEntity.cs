﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Domain
{
    public interface IEntity
    {
        public long Id { get; set; }
    }
}
