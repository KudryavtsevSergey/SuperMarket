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

        public void Remove(IProduct product)
        {
            if (products.ContainsKey(product))
            {
                if (products[product] == 1)
                {
                    products.Remove(product);
                }
                else
                {
                    products[product] -= 1;
                }
            }
        }

        public int Count()
        {
            return products.Count;
        }

        public double Check()
        {
            double sum = 0;
            foreach (KeyValuePair<IProduct, int> product in products)
            {
                if (product.Key.hasDiscount())
                {
                    IDiscount discount = product.Key.Discount;
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

        public void PrintCheck()
        {
            foreach (KeyValuePair<IProduct, int> product in products)
            {
                Console.WriteLine("Название: " + product.Key.Name + " Цена: " + product.Key.Price + " Количество: " + product.Value);
            }
            
        }

        public void PrintSum()
        {
            Console.WriteLine("Общая цена: " + this.Check());
        }

        public bool IsContain(string productName)
        {
            foreach(KeyValuePair<IProduct, int> product in products)
            {
                if(productName == product.Key.Name)
                {
                    return true;
                }
            }
            return false;
        }

        public int CountOneProduct(string productName)
        {
            foreach (KeyValuePair<IProduct, int> product in products)
            {
                if (productName == product.Key.Name)
                {
                    return product.Value;
                }
            }
            return 0;
        }
    }
}
