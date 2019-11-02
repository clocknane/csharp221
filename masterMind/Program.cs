using System;

namespace masterMind
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			Random random = new Random();
			int randomColor = random.Next();

			Console.WriteLine("Welcome to Mastermind!");
		}
	}
}