﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Application.Commands.Login
{
    public class LoginResponse
    {
        public string Token { get; set; }

        public string Message { get; set; }
    }
}
