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
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FazbearEntertainements_Project3
{
    internal class Warehouse
    {
        List<Dock> dockList { get; set; }
        public Queue<Truck> Entrance { get; set; }

        public Warehouse() 
        {
            dockList = new List<Dock>();
            Entrance = new Queue<Truck>();
        }

        public void Run()
        {
            //-----Options-----
            int increments = 48;
            int numOfTrucksCanArrive = 3;
            //-----------------

            Random rand = new Random();

            int numDocks = 0;

            while (true)
            {
                try
                {
                    Console.WriteLine("How many docks are there?");
                    numDocks = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }

            List<int> deckIDList = new List<int>();
            bool deckIDCheck = true;
            int randomDeckID = 0;

            for (int i = 0; i < numDocks; i++)
            {
                deckIDCheck = true;
                while (deckIDCheck == true)
                {
                    deckIDCheck = false;
                    randomDeckID = rand.Next(0, 1000000);
                    foreach (int item in deckIDList)
                    {
                        if (item == randomDeckID)
                        {
                            deckIDCheck = true;
                        }
                    }
                }
                deckIDList.Add(randomDeckID);
                Dock dock = new Dock(randomDeckID.ToString());
                dockList.Add(dock);
            }

            int arrivalFlip = 0;
            int amountofTrucksArrived = 0;
            for (int i = 1; i <= increments; i++)
            {
                arrivalFlip = rand.Next(0, 2);
                if (arrivalFlip == 0)
                {
                    amountofTrucksArrived = rand.Next(1, numOfTrucksCanArrive + 1);
                }
                for (int t = 0; t < amountofTrucksArrived; t++)
                {
                    Truck truck = new Truck(randomName(), "test");
                    Console.WriteLine(truck.Driver);
                }
            }

            /*
            -Log Includes-
            The time increment that the crate was unloaded
            The truck driver’s name
            The delivery company’s name
            The crate’s identification number
            The crate’s value
            A string indicating one of 3 scenarios:
                - A crate was unloaded, but the truck still has more crates to unload
                - A crate was unloaded, and the truck has no more crates to unload, and another truck is already in the Dock
                - A crate was unloaded, and the truck has no more crates to unload, but another truck is NOT already in the Dock
            
             */
        }
        public void WriteDataFile()
        {
            try
            {
                string filepath = $@"..\..\..\data\output\shipmentLog" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".csv";
                StreamWriter rwr = new StreamWriter(filepath, true);
                rwr.WriteLine($@"");
                rwr.Close();
            }
            catch
            {
                throw new FileLoadException();
            }

        }

        public string randomName()
        {
            Random random = new Random();
            int randName = random.Next(0, Enum.GetNames(typeof(Names)).Length);
            int randType = random.Next(1, 42);

            char[] nameArr = Convert.ToString((Names)Enum.Parse(typeof(Names), Convert.ToString(randName))).ToCharArray();
            string newName = "";
            foreach (char item in nameArr)
            {
                if (item != '_')
                {
                    newName += item;
                }
                else
                {
                    newName += " ";
                }
            }

            return newName;
        }
    }
}
