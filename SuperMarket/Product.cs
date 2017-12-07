using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket
{
    public class Product : IProduct
    {
        public IDiscount Discount { get; private set; }
        public string Name { get; private set; }
        public double Price { get; private set; }

        public Product(string name, double price, IDiscount discount = null)
        {
            this.Discount = discount;
            this.Name = name;
            this.Price = price;
        }

        public bool hasDiscount()
        {
            if (this.Discount == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
