using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Domain
{
    public interface Payment
    {
        bool Pay(double totalOrder, string creditCard);
    }
}
