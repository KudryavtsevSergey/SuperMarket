using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket
{ 
    class Program
    {
        static void Main(string[] args)
        {
            IDiscount discount = new Discount(3, 3);
            IProduct product = new Product("Roshen", 1.25, discount);
            ICashbox cashbox = new Cashbox();
            for (int i = 0; i < 5; i++)
            {
                cashbox.Scan(product);
            }
            Console.WriteLine(cashbox.Check());
            Console.ReadLine();
        }
    }
}
