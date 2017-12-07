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
            IDiscount discountRoshen = new Discount(3, 3);
            IProduct sweetRoshen = new Product("Roshen", 1.25, discountRoshen);
            IProduct sweetKomunarka = new Product("Komunarka", 4.25);

            IDiscount discountBanana = new Discount(6, 5);
            IProduct banana = new Product("Banana", 1, discountBanana);

            ICashbox cashbox = new Cashbox();
            for (int i = 0; i < 5; i++)
            {
                cashbox.Scan(sweetRoshen);
            }
            cashbox.Scan(sweetKomunarka);
            for (int i = 0; i < 12; i++)
            {
                cashbox.Scan(banana);
            }
            Console.WriteLine(cashbox.Check());
            cashbox.PrintCheck();
            cashbox.PrintSum();
            Console.WriteLine(cashbox.IsContain("Banana"));
            Console.WriteLine(cashbox.CountOneProduct("Banana"));
            Console.ReadLine();
        }
    }
}
