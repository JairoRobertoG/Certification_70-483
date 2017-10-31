using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certification.Classes
{
    class OrderSort : IComparable
    {
        public DateTime Created { get; set; }
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            OrderSort o = obj as OrderSort;
            if (o == null)
            {
                throw new ArgumentException("Object is not an Order");
            }
            return this.Created.CompareTo(o.Created);
        }
    }
}
