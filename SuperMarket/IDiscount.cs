﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket
{
    public interface IDiscount
    {
        int Count { get; }
        double Price { get; }
    }
}
