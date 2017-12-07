using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket
{
    public class Discount : IDiscount
    {
        public int Count { get; private set; }
        public double Price { get; private set; }

        public Discount(int count, double price)
        {
            this.Count = count;
            this.Price = price;
        }
    }
}
