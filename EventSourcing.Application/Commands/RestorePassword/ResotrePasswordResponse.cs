using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Application.Commands.RestorePassword
{
    public class ResotrePasswordResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
