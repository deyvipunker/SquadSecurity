using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadSecurity.Shared.Responses
{
    public class ActionResponse<T>
    {
        public bool WasSucceess { get; set; }
        public string? Message { get; set; }
        public T? Result { get; set; }
    }
}
