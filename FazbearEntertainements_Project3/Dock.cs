using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FazbearEntertainements_Project3
{
    internal class Dock
    {
        /// <summary>
        /// Short Hand Getters and Setters for all important variables 
        /// </summary>
        public string Id { get; private set; }
        public Queue<Truck> Line { get; private set; }
        public double TotalSales { get; private set; }
        public int TotalCrates { get; private set; }
        public int TotalTrucks { get; private set; }
        public int TimeInUse { get; private set; }
        public int TimeNotInUse { get; private set; }

        /// <summary>
        /// Parameterized Constructer for the Dock of the Warehouse
        /// </summary>
        /// <param name="id">ID number that is given when created along side the Warehouse</param>
        public Dock(string id)
        {
            Id = id;
            Line = new Queue<Truck>();
            TotalSales = 0;
            TotalCrates = 0;
            TotalTrucks = 0;
            TimeInUse = 0;
            TimeNotInUse = 0;
        } //End of Parameterized Constructor

        /// <summary>
        /// To allow trucks to join line for access to dock
        /// </summary>
        /// <param name="truck">Truck given to join the queue fo trucks for the dock</param>
        public void JoinLine(Truck truck)
        {
            Line.Enqueue(truck);
        } //End of Method "JoinLine"

        /// <summary>
        /// To remove truck from dock to allow for new truck to enter
        /// </summary>
        /// <returns>Truck to be recognized for leaving</returns>
        public Truck SendOff()
        {
            Truck truck = Line.Dequeue();
            TotalTrucks++;
            return truck;
        } //End of Method "SendOff"
    } //End of Class "Dock"
} //End of NameSpace "FazbearEntertainements_Project3"
