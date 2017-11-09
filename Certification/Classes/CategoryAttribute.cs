using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certification.Classes
{
    public class CategoryAttribute
    {
        public CategoryAttribute(string value)
        { }
    }

    public class UnitTestAttribute : CategoryAttribute
    {
        public UnitTestAttribute()
        : base("Unit Test")
        { }
    }
}
