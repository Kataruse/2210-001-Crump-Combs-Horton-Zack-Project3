using System;

public class Crate
{
	Random randPrice = new Random(50, 501);
	Random randId = new Random(0, 1000000)

    public Crate(string id, double price)
	{
		id = randId;
		price = randPrice;
	}
}
