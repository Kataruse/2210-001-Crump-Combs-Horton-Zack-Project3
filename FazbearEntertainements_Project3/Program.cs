﻿///////////////////////////////////////////////////////////////////////////////
//
// Author: Ethan Horton, hortonew@etsu.edu
//         Elijah Combs, combsey@etsu.edu
//         Nicholas Crump, crumpna@etsu.edu
//         Zackary Jordan, jordanzd@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Project 3
// Description: This runs a simulation of a day in the warehouse.
//              
//
//
///////////////////////////////////////////////////////////////////////////////
namespace FazbearEntertainements_Project3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Warehouse warehouse = new Warehouse();
            warehouse.Run();
        }
    }
}