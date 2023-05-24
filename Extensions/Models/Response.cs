using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Extensions.Models
{
    public class Response
    {
        public string Message { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}