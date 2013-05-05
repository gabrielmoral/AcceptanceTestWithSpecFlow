using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Domain
{
    public class Item
    {
        private string name;
        private double price;

        public string Name
        {
            get { return name; }        
        }      

        public double Price
        {
            get { return price; }        
        }

        public Item(string name, double price)
        {
            this.name = name;
            this.price = price;                
        }   
    }
}
