using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FazbearEntertainements_Project3
{
    internal class Truck<T>
    {
        public string Driver { get; set; }
        public string DeliveryCompany { get; set; }
        public Stack<T> Trailer { get; set; }

        public Truck(string driver, string deliveryCompany)
        {
            Driver = driver;
            DeliveryCompany = deliveryCompany;
            Trailer = new Stack<T>(15);
        }
    }
}
