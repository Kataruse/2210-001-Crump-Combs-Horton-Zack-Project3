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
            string dateTime = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");

            //-----Options-----
            int increments = 48;
            int numOfTrucksCanArrive = 3;
            //-----------------

            //--Report Values--
            int numDocks = 0;
            double revenue = 0.00;
            int longestLine = 0;
            int numTrucksProcessed = 0;
            int numCratesUnloaded = 0;
            double totalCratesUnloadedValue = 0.00;
            double averageCrateValue = 0.00;
            double averageTruckValue = 0.00;
            //  For Each Dock
            //The total amount of time that a dock was in use.
            //The total amount of time that a dock was not in use.
            //The average amount of time that a dock was in use.
            //The total cost of operating each dock.
            //-----------------

            Random rand = new Random();

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

            int arrivalFlip1 = 0;
            int arrivalFlip2 = 0;
            int amountofTrucksArrived = 0;

            if (numOfTrucksCanArrive < 1)
            {
                numOfTrucksCanArrive = 1;
            }

            int subNumOfTrucksCanArrive = Convert.ToInt32(Math.Floor(Convert.ToDecimal(numOfTrucksCanArrive / 2)));
            if (subNumOfTrucksCanArrive < 1)
            {
                subNumOfTrucksCanArrive = 1;
            }

            int addNumOfTrucksCanArrive = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(numOfTrucksCanArrive / 2)));

            for (int i = 1; i <= increments; i++)
            {


                if (i > 24 && i < 34)
                {
                    //x2 more chance to have trucks
                    arrivalFlip1 = rand.Next(0, 2);
                    arrivalFlip2 = rand.Next(0, 2);
                    if (arrivalFlip1 == 0 || arrivalFlip2 == 0)
                    {
                        amountofTrucksArrived = rand.Next(1, numOfTrucksCanArrive + addNumOfTrucksCanArrive);
                    }
                    else
                    {
                        amountofTrucksArrived = 0;
                    }
                }
                else if (i < 12 || i > 44)
                {
                    //x2 less chance to have trucks
                    arrivalFlip1 = rand.Next(0, 2);
                    arrivalFlip2 = rand.Next(0, 2);
                    if (arrivalFlip1 == 0 && arrivalFlip2 == 0)
                    {
                        amountofTrucksArrived = rand.Next(1, subNumOfTrucksCanArrive + 1);
                    }
                    else
                    {
                        amountofTrucksArrived = 0;
                    }
                }
                else
                {
                    //normal chance to have trucks
                    arrivalFlip1 = rand.Next(0, 2);
                    if (arrivalFlip1 == 0)
                    {
                        amountofTrucksArrived = rand.Next(1, numOfTrucksCanArrive + 1);
                    }
                    else
                    {
                        amountofTrucksArrived = 0;
                    }
                }
                for (int t = 0; t < amountofTrucksArrived; t++)
                {
                    Truck truck = new Truck(randomName(), randomCompany());
                    for(int j = 0; j < rand.Next(1,16); j++)
                    {
                        Crate crate = new Crate();
                        truck.Load(crate);
                    }
                    Entrance.Enqueue(truck);
                }

                int shortestDockLengthIndex = 0;
                for (int d = 1; d < numDocks; d++)
                {
                    if (dockList[d - 1].Line.Count > dockList[d].Line.Count)
                    {
                        shortestDockLengthIndex = d;
                    }
                }
                if (Entrance.Count > 0)
                {
                    dockList[shortestDockLengthIndex].JoinLine(Entrance.Dequeue());
                }
                

                for (int d = 0; d < numDocks; d++)
                {
                    if (dockList[d].Line.Count > 0)
                    {
                        dockList[d].Line.Peek().Unload();
                        if (dockList[d].Line.Peek().Trailer.Count == 0)
                        {
                            dockList[d].SendOff();
                        }
                    }
                }

                for (int d = 0; d < numDocks; d++)
                {
                    if (dockList[d].Line.Count > 0)
                    {
                        revenue = revenue - 100.00;
                    }
                }
            }
            Console.WriteLine(revenue);
        }
        public void WriteShipmentLog(string dateTime, int increment, string name, string company, string crateID, double cratePrice, string dockState)
        {
            /*
            A string indicating one of 3 scenarios:
                - A crate was unloaded, but the truck still has more crates to unload
                - A crate was unloaded, and the truck has no more crates to unload, and another truck is already in the Dock
                - A crate was unloaded, and the truck has no more crates to unload, but another truck is NOT already in the Dock
            */
            try
            {
                string filepath = $@"..\..\..\data\output\shipmentLog" + dateTime + ".csv";
                StreamWriter rwr = new StreamWriter(filepath, true);
                rwr.WriteLine($@"{increment},{name},{company},{crateID},{cratePrice},{dockState}");
                rwr.Close();
            }
            catch
            {
                throw new FileLoadException();
            }

        }

        public void WriteReport(string dateTime, int numDocks, double revenue, int longestLine, int numTrucksProcessed, int numCratesUnloaded, double totalCratesUnloadedValue, double averageCrateValue, double averageTruckValue)
        {
            try
            {
                string filepath = $@"..\..\..\data\output\shipmentReport" + dateTime + ".csv";
                StreamWriter rwr = new StreamWriter(filepath, true);
                rwr.WriteLine($@"{numDocks},{revenue},{longestLine},{numTrucksProcessed},{numCratesUnloaded},{totalCratesUnloadedValue},{averageCrateValue},{averageTruckValue},,dockTimeUse,dockTimeNotUse,dockTimeUseAvg,dockCost");
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

        public string randomCompany()
        {
            Random random = new Random();
            int randCompany = random.Next(0, Enum.GetNames(typeof(Companies)).Length);
            int randType = random.Next(1, 44);

            char[] nameArr = Convert.ToString((Companies)Enum.Parse(typeof(Companies), Convert.ToString(randCompany))).ToCharArray();
            string newCompany = "";
            foreach (char item in nameArr)
            {
                if (item != '_')
                {
                    newCompany += item;
                }
                else
                {
                    newCompany += " ";
                }
            }

            return newCompany;
        }
    }
}
