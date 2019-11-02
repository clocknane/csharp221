using System;
using System.Collections.Generic;

namespace gradeBook
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			string name;

			Console.WriteLine("Hello, please enter the student name: ");
			name = Console.ReadLine();

			Dictionary<string, string[]> students = new Dictionary<string, string[]>();

			students.Add("names", new string[] { "Chance" });
			students.Add("grades", new string[] { "100 90 78 101 45 81" });

			foreach (string names in students["names"])
			{
				Console.WriteLine(name);
			}

			Console.WriteLine("");
			Console.WriteLine("");

			Console.ReadLine();
		}
	}
}