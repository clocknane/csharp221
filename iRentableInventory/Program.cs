using System;
using System.Collections.Generic;

namespace Inventory
{
	internal class Program
	{
		private static List<IRentable> InventoryList = new List<IRentable>();

		private static void Main(string[] args)
		{
			IRentable boat1 = new Boat("Boat Number One!");
			IRentable boat2 = new Boat("Boat Number Two!");
			IRentable car1 = new Car("Car Number One!");
			IRentable car2 = new Car("Car Number Two!");
			IRentable house1 = new House("House Number One!");
			IRentable house2 = new House("House Number Two!");

			InventoryList.AddRange(new IRentable[] { boat1, boat2, car1, car2, house1, house2 });

			foreach (IRentable item in InventoryList)
			{
				Console.WriteLine(item.GetType().Name);
				Console.WriteLine("Daily Rate: " + item.GetDailyRate());
				Console.WriteLine(item.GetDescription() + "\n");
			}

			Console.Read();
		}
	}

	public interface IRentable
	{
		decimal GetDailyRate();

		string GetDescription();
	}

	#region Boat

	public class Boat : IRentable
	{
		private decimal _hourlyRate = 27.00m;
		private string Description { get; set; }

		public Boat(string description)
		{
			Description = description;
		}

		public decimal GetDailyRate()
		{
			return Decimal.Round(_hourlyRate * 24, 2);
		}

		public string GetDescription()
		{
			return Description;
		}
	}

	#endregion Boat

	#region House

	public class House : IRentable
	{
		private decimal _weeklyRate = 270.00m;
		private string Description { get; set; }

		public House(string description)
		{
			Description = description;
		}

		public decimal GetDailyRate()
		{
			return Decimal.Round(_weeklyRate / 7, 2);
		}

		public string GetDescription()
		{
			return Description;
		}
	}

	#endregion House

	#region Car

	public class Car : IRentable
	{
		private decimal _dailyRate = 36.00m;
		private string Description { get; set; }

		public Car(string description)
		{
			Description = description;
		}

		public decimal GetDailyRate()
		{
			return _dailyRate;
		}

		public string GetDescription()
		{
			return Description;
		}
	}

	#endregion Car
}