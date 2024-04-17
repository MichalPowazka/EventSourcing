using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Application.Commands.UpdateOpinion
{
    public class UpdateOpinionResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
