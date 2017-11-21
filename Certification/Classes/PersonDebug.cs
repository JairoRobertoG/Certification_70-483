using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certification.Classes
{
    [DebuggerDisplay("Name = {FirstName} {LastName")]
    public class PersonDebug
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
