using System;
using System.Collections.Generic;

namespace poCos
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			driversLicense driver = new driversLicense("Chance", "Locknane", "Male", "TX062109")
			{
			};

			Console.WriteLine(driver.Name());
			Console.ReadKey();
		}
	}
}

public class driversLicense
{
	public string firstName = string.Empty;
	public string lastName = string.Empty;
	public string Gender = string.Empty;
	public string licenseNumber = string.Empty;

	public driversLicense(String initialFirstName, String initialLastName, String initialGender, String initialLicenseNumber)
	{
		this.firstName = initialFirstName;
		this.lastName = initialLastName;
		this.Gender = initialGender;
		this.licenseNumber = initialLicenseNumber;
	}

	public string Name()
	{
		string FullName = firstName + " " + lastName;
		return FullName;
	}
}

internal class Book
{
	public string Title { get; private set; }
	public List<string> Authors { get; private set; }
	public string Pages { get; private set; }
	public string SKU { get; private set; }
	public string Publisher { get; private set; }
	public string Price { get; private set; }

	public Book(string WarandPeace, string LeoTolstoy, string P1225, string B28401, string TheRussianMessenger, string cost)
	{
		Title = WarandPeace;
		Authors.Add(LeoTolstoy);
		Pages = P1225;
		SKU = B28401;
		Publisher = TheRussianMessenger;
		Price = cost;
	}
}

public class Airplane
{
	public string Manufacturer { get; private set; }
	public string Model { get; private set; }
	public string Variant { get; private set; }
	public string Capacity { get; private set; }
	public string Engines { get; private set; }

	public Airplane(string Boeing, string Hornet, string F18, string ThirtyTwoThousandPounds, string GEF404)
	{
		Manufacturer = Boeing;
		Model = Hornet;
		Variant = F18;
		Capacity = ThirtyTwoThousandPounds;
		Engines = GEF404;
	}
}