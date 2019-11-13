using System;
using System.Collections.Generic;

namespace CarLot
{
	#region Main

	internal class Program
	{
		private static void Main(string[] args)
		{
			Vehicle c1 = new Car("sedan", 4)
			{
				Make = "Buick",
				Model = "Regal GS",
				licenseNumber = "JWD2567",
				Price = 37000
			};
			Vehicle c2 = new Car("coup", 2)
			{
				Make = "Audi",
				Model = "RS-5 Sportback",
				licenseNumber = "MCP6793",
				Price = 75000
			};
			Vehicle t1 = new Truck(13)
			{
				Make = "Chevy",
				Model = "Silverado LTZ",
				licenseNumber = "LRZ3490",
				Price = 57960
			};
			Vehicle t2 = new Truck(13)
			{
				Make = "Toyota",
				Model = "Tundra",
				licenseNumber = "HRW9810",
				Price = 48625
			};

			CarLot lot1 = new CarLot("Shawnda's Auto Sales");
			lot1.Add(c1);
			lot1.Add(c2);
			lot1.Printout();
			CarLot lot2 = new CarLot("Chance's Trucks");
			lot2.Add(t1);
			lot2.Add(t2);
			lot2.Printout();
			Console.Read();
		}
	}

	#endregion Main

	#region Car Lot

	internal class CarLot
	{
		protected string Name { get; }

		private List<Vehicle> Vehicles = new List<Vehicle>();

		public CarLot(string name)
		{
			Name = name.ToUpper();
		}

		public void Add(Vehicle vehicle)
		{
			Vehicles.Add(vehicle);
		}

		public void Printout()
		{
			int num = 1;

			Console.WriteLine(Name);
			Console.WriteLine("Vehicle Inventory:\n");

			foreach (Vehicle vehicle in Vehicles)
			{
				Console.WriteLine($"({num})");
				Console.WriteLine(vehicle.Description() + "\n");
				num++;
			}
		}
	}

	#endregion Car Lot

	#region Vehicle

	internal abstract class Vehicle
	{
		public string licenseNumber;
		public string Make;
		public string Model;
		public int Price;

		public virtual string Description()
		{
			return "This is a Vehicle Description";
		}
	}

	#endregion Vehicle

	#region Car

	internal class Car : Vehicle
	{
		protected string Type { get; set; }
		protected int Doors { get; set; }

		public Car(string t, int num)
		{
			Type = t.ToUpper();
			Doors = num;
		}

		public override string Description()
		{
			return $"[Make: {Make}\n Model: {Model}\n Type: {Type}\n Number of Doors: {Doors}\n License Number: {licenseNumber}\n Price: ${Price}]";
		}
	}

	#endregion Car

	#region Truck

	internal class Truck : Vehicle
	{
		protected int bedSize { get; set; }

		public Truck(int ft)
		{
			bedSize = ft;
		}

		public override string Description()
		{
			return $"[Make: {Make}\n Model: {Model}\n Bed Size in sq-ft: {bedSize}\n License Number: {licenseNumber}\n Price: ${Price}]";
		}
	}

	#endregion Truck
}