using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FazbearEntertainements_Project3
{
    internal class Dock
    {
        public string Id {get; private set;}
        public Queue<Truck> Line { get; private set;}
        public double TotalSales { get; private set;}
        public int TotalCrates {get; private set;}
        public int TotalTrucks { get; private set;}
        public int TimeInUse {get; private set;}
        public int TimeNotInUse {get; private set;}

        public void JoinLine()
        {

        }

        public Truck SendOff()
        {

        }
    }
}
