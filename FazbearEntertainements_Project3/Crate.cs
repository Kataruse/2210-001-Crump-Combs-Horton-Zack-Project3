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

public class Crate
{
	Random rand = new Random();
    //Random randPrice = new rand(50, 501);
    //Random randId = new Random(0, 1000000);
    public string Id { get; private set; }
    public double price { get; private set; }

    public Crate()
	{
		Id = rand.Next(0, 1000000).ToString();
		price = Convert.ToDouble(rand.Next(50, 501));
	}
}
