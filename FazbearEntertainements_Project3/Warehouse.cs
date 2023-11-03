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
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace FazbearEntertainements_Project3
{
    internal class Warehouse
    {
        //List<Dock> dock { get; set; }
        //Queue Entrance – All trucks must pass through the warehouse entrance before being joining a line at a Dock.
        //Any properties you deem necessary to complete a run of the simulation.

        public void Run()
        {
            //Runs the simulation. More details below.

            //When running the simulation, log each crate as it loaded off the truck into a CSV file. Each row of
            //data should include:

            //The time increment that the crate was unloaded
            //The truck driver’s name
            //The delivery company’s name
            //The crate’s identification number
            //The crate’s value
            //A string indicating one of 3 scenarios:
            //A crate was unloaded, but the truck still has more crates to unload
            //A crate was unloaded, and the truck has no more crates to unload, and another
            //truck is already in the Dock
            //A crate was unloaded, and the truck has no more crates to unload, but another
            //truck is NOT already in the Dock
        }

        public void WriteDataFile()
        {
            try
            {
                
                string filepath = $@"..\..\..\data\output\shipmentLog.csv";
                StreamWriter rwr = new StreamWriter(filepath, true);

                rwr.WriteLine($@"" + DateTime.Now.ToString());

                rwr.Close();
            }
            catch
            {
                throw new FileLoadException();

            }
            //Any methods you deem necessary to complete a run of the simulation.

        }
    }
}
