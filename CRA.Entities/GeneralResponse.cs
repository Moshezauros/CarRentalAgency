using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRA.Entities
{
    public class GeneralResponse
    {
        public GeneralResponse()
        {
            Errors = new List<string>();
        }

        public bool IsValid { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
    }
}
