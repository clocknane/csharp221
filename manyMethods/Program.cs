using System;

namespace ManyMethods
{
	internal class Program
	{
		private static void Main()
		{
			Hello();
			Addition();
			CatDog();
			OddEvent();
			Inches();
			Echo();
			KillGrams();
			Date();
			Age();
			Guess();
		}

		public static void Hello()
		{
			Console.WriteLine("Hello, please tell me your name");
			String name = Console.ReadLine();
			Console.WriteLine("Hello, " + name);
		}

		public static void Addition()
		{
			int num1;
			int num2;
			Console.WriteLine("Please enter your first number: ");
			num1 = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Please enter your second number: ");
			num2 = Convert.ToInt32(Console.ReadLine());
			_ = num1 + num2;
			Console.WriteLine(_ = num1 + num2);
		}

		public static void CatDog()
		{
			Console.WriteLine("Do you like cats or dogs?");
			string answer = Console.ReadLine();

			if (answer == "cats")
			{
				Console.WriteLine("meow");
			}
			else
				Console.WriteLine("woof");
		}

		public static void OddEvent()
		{
			Console.WriteLine("Please enter a number");
			string num = Console.ReadLine();
			int number = int.Parse(num);
			if (number % 2 == 0)
			{
				Console.WriteLine("Number is even");
			}
			else
			{
				Console.WriteLine("Number is odd");
			}
		}

		public static void Inches()
		{
			double inch;
			Console.WriteLine("Enter height in feet: ");
			double feet = Convert.ToDouble(Console.ReadLine());
			inch = feet * 12;
			Console.WriteLine("{0} feet : {1} Inches", feet, inch);
		}

		public static void Echo()
		{
			Console.WriteLine("Please enter a word");
			string reply = Console.ReadLine();
			string upperReply = reply.ToUpper();
			Console.WriteLine(upperReply);
			Console.WriteLine(reply);
			Console.WriteLine(reply);
		}

		public static void KillGrams()
		{
			Console.WriteLine("Please enter weight in pounds");
			double pounds = Convert.ToDouble(Console.ReadLine());
			double kg = pounds * 0.45359237;
			Console.WriteLine(pounds + " pounds is " + kg + " kilograms");
		}

		public static void Date()
		{
			Console.WriteLine("What time is it?");
			var date = DateTime.Now;
			Console.WriteLine(date);
		}

		public static void Age()
		{
			Console.WriteLine("What year were you born?: ");
			var response = Convert.ToString(Console.ReadLine());
			Console.WriteLine(response);
			DateTime todayDate = DateTime.Today;
			Console.WriteLine(todayDate.Year);
			int age = todayDate.Year - Convert.ToInt32(response);
			Console.WriteLine(age);
		}

		public static void Guess()
		{
			Console.WriteLine("Please guess a word: ");
			string response = Console.ReadLine();
			Console.WriteLine(response);
			if (response == "csharp")
			{
				Console.WriteLine("Correct!");
				Console.ReadLine();
			}
			else
			{
				Console.WriteLine("Wrong!");
				Console.ReadLine();
			}
		}
	}
}