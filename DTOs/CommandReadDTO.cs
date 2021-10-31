using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoolApi.DTOs
{
    public class CommandReadDTO
    {
        public int CommandId { get; set; }

        public string HowTo { get; set; }
        
        public string Line { get; set; }
        
        // public string Platform { get; set; }
    }
}