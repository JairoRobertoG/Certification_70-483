using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certification.Classes
{
    class Derived2 : Derived
    {
        // This line would give a compile error
        //public override int MyMethod() { return 1;}
    }
}
