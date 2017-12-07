using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket
{
    public interface ICashbox
    {
        void Scan(IProduct product);
        void Remove(IProduct product);
        double Check();
        void PrintCheck();
        void PrintSum();
        bool IsContain(string productName);
        int CountOneProduct(string productName);
        int Count();
    }
}
