using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket
{
    public class Product : IProduct
    {
        private IDiscount discount;
        public string Name { get; private set; }
        public double Price { get; private set; }

        public Product(string name, double price, IDiscount discount = null)
        {
            this.discount = discount;
            this.Name = name;
            this.Price = price;
        }

        public bool hasDiscount()
        {
            if (this.discount == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public IDiscount getDiscount()
        {
            return this.discount;
        }
    }
}
