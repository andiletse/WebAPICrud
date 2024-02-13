using BAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Responses
{
    internal class EditPersonResponse
    {
        public Person person { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
