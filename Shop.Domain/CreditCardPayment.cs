using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Domain
{
    public class CreditCardPayment : Payment
    {
        public bool Pay(double totalOrder, string creditCard)
        {
            return true;
        }
    }
}
