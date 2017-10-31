using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certification.Classes
{
    public class Product
    {
        public decimal Price { get; set; }
    }

    public static class MyExtensions
    {
        public static decimal Discount(this Product product)
        {
            return product.Price * .9M;
        }
    }
    public class Calculator1
    {
        public decimal CalculateDiscount(Product p)
        {
            return p.Discount();
        }
    }
}
