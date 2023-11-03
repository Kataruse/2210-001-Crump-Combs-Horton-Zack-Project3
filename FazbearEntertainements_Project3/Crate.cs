using System;

public class Crate
{
	Random rand = new Random();
	//Random randPrice = new rand(50, 501);
	//Random randId = new Random(0, 1000000);

    public Crate(string id, double price)
	{
		id = rand.Next(0, 1000000).ToString();
		price = Convert.ToDouble(rand.Next(50, 501));
	}
}
