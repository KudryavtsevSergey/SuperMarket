using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket
{
    public class Cashbox : ICashbox
    {
        private Dictionary<IProduct, int> products;

        public Cashbox()
        {
            products = new Dictionary<IProduct, int>();
        }

        public void Scan(IProduct product)
        {
            if (products.ContainsKey(product))
            {
                products[product] += 1;
            }
            else
            {
                products.Add(product, 1);
            }
        }

        public double Check()
        {
            double sum = 0;
            foreach (KeyValuePair<IProduct, int> product in products)
            {
                if (product.Key.hasDiscount())
                {
                    IDiscount discount = product.Key.getDiscount();
                    sum += discount.Price * (product.Value / discount.Count);
                    sum += product.Key.Price * (product.Value % discount.Count);
                }
                else
                {
                    sum +=product.Key.Price * product.Value;
                }
            }
            return sum;
        }

    }
}
