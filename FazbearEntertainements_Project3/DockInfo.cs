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
        public int inUseTime { get; set; }
        public int notInUseTime { get; set; }
        public decimal avgTimeInUse { get; set; }
        public double totalCost { get; set; }

        public DockInfo() 
        { 
            inUseTime = 0;
            notInUseTime = 0;
            avgTimeInUse = 0;
            totalCost = 0.00;
        }

        public void IncreaseUseTime()
        {
            inUseTime += 1;
        }

        public void SetNotInUseTime(int increments)
        {
            notInUseTime = increments - inUseTime;
        }

        public void SetAvgTimeInUse(int increments)
        {
            avgTimeInUse = Convert.ToDecimal(inUseTime) / increments;
            avgTimeInUse = Math.Round(avgTimeInUse * 100,0);
        }

        public void IncreaseTotalCost(double cost)
        {
            totalCost += cost;
        }

        public void decreaseTotalCost(double cost)
        {
            totalCost -= cost;
        }
    }
}
