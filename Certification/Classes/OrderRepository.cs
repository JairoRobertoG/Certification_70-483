using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certification.Classes
{
    class OrderRepository : Repository<Order>
    {
        public OrderRepository(IEnumerable<Order> orders) : base(orders) { }

        public IEnumerable<Order> FilterOrdersOnAmount(decimal amount)
        {
            List<Order> result = null;
            // Some filtering code
            return result;
        }
    }
}
