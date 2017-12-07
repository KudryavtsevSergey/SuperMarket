using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket
{
    public interface IProduct
    {
        string Name { get; }
        double Price { get; }
        IDiscount Discount { get; }
        bool hasDiscount();
    }
}
