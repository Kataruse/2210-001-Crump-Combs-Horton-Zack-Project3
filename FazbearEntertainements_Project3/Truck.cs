///////////////////////////////////////////////////////////////////////////////
//
// Author: Ethan Horton, hortonew@etsu.edu
//         Elijah Combs, combsey@etsu.edu
//         Nicholas Crump, crumpna@etsu.edu
//         Zackary Jordan, jordanzd@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Project 3
// Description: 
//              
//
//
///////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FazbearEntertainements_Project3
{
    internal class Truck
    {
        public string Driver { get; set; }
        public string DeliveryCompany { get; set; }
        public Stack<Crate> Trailer { get; set; }

        public Truck(string driver, string deliveryCompany)
        {
            Driver = driver;
            DeliveryCompany = deliveryCompany;
            Trailer = new Stack<Crate>(15);
        }
        
        /// <summary>
        /// Loads a crate starting at the back of the truck.
        /// </summary>
        /// <param name="crate">Crate to load into the truck.</param>
        public void Load(Crate crate)
        {
            Trailer.Push(crate);
        }

        /// <summary>
        /// Unloads a crate starting from the front of the truck.
        /// </summary>
        /// <returns></returns>
        public Crate Unload()
        {
            Crate crateToUnload = Trailer.Pop();
            return crateToUnload;
        }
    }
}
