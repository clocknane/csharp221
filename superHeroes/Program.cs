using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroes
{
	internal class Program
	{
		private static List<Person> personList = new List<Person>();

		private static void Main(string[] args)
		{
			addToList();
			PrintList();
			Console.Read();
		}

		#region List Creation

		public static void addToList()
		{
			Person p1 = new Person("Cody", "Codeman");
			Person p2 = new Person("Paul", "P-Diddy");
			SuperHero sh1 = new SuperHero("Super Steve", "Steve Johnson", "Super Punch");
			SuperHero sh2 = new SuperHero("Flashy Franky", "Frank Smith", "Flash Blinding Light in Villain Eyes");
			Villain v1 = new Villain("Terrible Tommy", "Super Steve");
			Villain v2 = new Villain("Death-Defying Doug", "Flashy Franky");

			personList.AddRange(new Person[] { p1, p2, sh1, sh2, v1, v2 });
		}

		#endregion List Creation

		#region Print

		public static string PrintList()
		{
			foreach (Person obj in personList)
			{
				Console.WriteLine(obj.Name + ": " + obj.PrintGreeting() + "\n");
			}

			return null;
		}

		#endregion Print
	}

	#region Person

	internal class Person
	{
		public string Name { get; set; }
		public string NickName { get; set; }

		public Person(string name, string nickname)
		{
			Name = name;
			NickName = nickname;
		}

		public string ToString()
		{
			return Name;
		}

		public virtual string PrintGreeting()
		{
			return $"Hi, my name is {Name}, you can call me {NickName}.";
		}
	}

	#endregion Person

	#region Super Hero

	internal class SuperHero : Person
	{
		protected string RealName { get; set; }
		protected string SuperPower { get; set; }

		public SuperHero(string name, string real, string super) : base(name, null)
		{
			RealName = real;
			SuperPower = super;
		}

		public override string PrintGreeting()
		{
			return $"I am {RealName}. When I am {Name}, my super power is {SuperPower}!";
		}
	}

	#endregion Super Hero

	#region Villain

	internal class Villain : Person
	{
		protected string Nemesis { get; set; }

		public Villain(string name, string nemesis) : base(name, null)
		{
			Nemesis = nemesis;
		}

		public override string PrintGreeting()
		{
			return $"I am {Name}! Have you seen {Nemesis}?!";
		}
	}

	#endregion Villain
}