///////////////////////////////////////////////////////////////////////////////
//
// Author: Ethan Horton, hortonew@etsu.edu
//         Elijah Combs, combsey@etsu.edu
//         Nicholas Crump, crumpna@etsu.edu
//         Zackary Jordan, jordanzd@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Project 3
// Description: This is the crate class, which is used to unload from the 
//              trucks so that the warehouse can make sales. 
//              
//
//
///////////////////////////////////////////////////////////////////////////////
using System;

public class Crate
{
    //rand allows the crate to be assigned a random ID and a random price
	Random rand = new Random();
    public string Id { get; private set; }
    public double price { get; private set; }

    /// <summary>
    /// Creates an instance of the crate class without parameters
    /// </summary>
    public Crate()
	{
		Id = rand.Next(0, 1000000).ToString();
		price = Convert.ToDouble(rand.Next(50, 501));
	}

    /// <summary>
    /// Creates an instance of the crate class with the ID provided by the user.
    /// </summary>
    /// <param name="_Id">ID provided by user</param>
    public Crate(int _Id)
    {
        Id = Convert.ToString(_Id);
        price = Math.Round(rand.NextDouble() * (500 - 50) + 50, 2);
    }
}
