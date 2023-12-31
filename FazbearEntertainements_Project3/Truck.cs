﻿///////////////////////////////////////////////////////////////////////////////
//
// Author: Ethan Horton, hortonew@etsu.edu
//         Elijah Combs, combsey@etsu.edu
//         Nicholas Crump, crumpna@etsu.edu
//         Zackary Jordan, jordanzd@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Project 3
// Description: This is the truck class, which is used to carry crates and take
//              them to the dock to be unloaded. 
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
        Random rand = new Random();
        public int TruckID { get; set; }
        public string Driver { get; set; }
        public string DeliveryCompany { get; set; }
        public Stack<Crate> Trailer { get; set; }

        /// <summary>
        /// Creates an instance of the truck class.
        /// </summary>
        /// <param name="driver">Name of the driver</param>
        /// <param name="deliveryCompany">Name of the delivery company</param>
        /// <param name="truckID"># associated to the truck</param>
        public Truck(string driver, string deliveryCompany, int truckID)
        {
            TruckID = truckID;
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
        /// <returns>The crate that was unloaded from the truck.</returns>
        public Crate Unload()
        {
            Crate crateToUnload = Trailer.Pop();
            return crateToUnload;
        }
    }
}
