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
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FazbearEntertainements_Project3
{
    internal class DockInfo
    {
        /// <summary>
        /// Short Hand Getters and Setters for all important variables 
        /// </summary>
        public int inUseTime { get; set; }
        public int notInUseTime { get; set; }
        public decimal avgTimeInUse { get; set; }
        public double totalCost { get; set; }

        /// <summary>
        /// Parameterized Constructer for the Info of the Dock
        /// </summary>
        public DockInfo() 
        { 
            inUseTime = 0;
            notInUseTime = 0;
            avgTimeInUse = 0;
            totalCost = 0.00;
        }

        /// <summary>
        /// Increase the dock's time in use
        /// </summary>
        public void IncreaseUseTime()
        {
            inUseTime += 1;
        }

        /// <summary>
        /// sets the time the dock was not in use
        /// </summary>
        /// <param name="increments">how long the simulation runs</param>
        public void SetNotInUseTime(int increments)
        {
            notInUseTime = increments - inUseTime;
        }

        /// <summary>
        /// sets the average time the dock was in use
        /// </summary>
        /// <param name="increments">how long the simulation runs</param>
        public void SetAvgTimeInUse(int increments)
        {
            avgTimeInUse = Convert.ToDecimal(inUseTime) / increments;
            avgTimeInUse = Math.Round(avgTimeInUse * 100,0);
        }

        /// <summary>
        /// increases the cost of the dock by adding the cost
        /// </summary>
        /// <param name="cost">cost to be added</param>
        public void IncreaseTotalCost(double cost)
        {
            totalCost += cost;
        }

        /// <summary>
        /// decreases the cost of the dock by adding the cost
        /// </summary>
        /// <param name="cost">cost to be removed</param>
        public void decreaseTotalCost(double cost)
        {
            totalCost -= cost;
        }
    }
}
