using System;

public class Crate
{

	string _id { get; set; }
	double _price { get; set; }

    public Crate(string id, double price)
	{
		_id = id;
		_price = price;
	}
}
