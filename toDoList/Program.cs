using System;
using System.Collections.Generic;

namespace toDoList
{
	public class ToDoList
	{
		public string Description { get; set; }
		public string DueDate { get; set; }
		public string Priority { get; set; }

		public ToDoList(string Desc, string Date, string Prio)
		{
			Description = Desc;
			DueDate = Date;
			Priority = Prio;
		}

		private class Program
		{
			private static List<ToDoList> ToDoListings = new List<ToDoList>();

			private static void Main(string[] args)
			{
				CreateItems();
				OutPut();
				Console.Read();
			}

			public static void CreateItems()
			{
				Console.WriteLine("Welcome, this is your To Do List");
				Console.WriteLine("Would you like to add an item or see current list? Yes/No: ");
				string Choice = Console.ReadLine().ToLower();

				while (Choice != "show")
				{
					Console.WriteLine("Please Enter Your Description: ");
					string description = Console.ReadLine();

					Console.WriteLine("Please Enter Due Date in the format mm/dd/yyyy: ");
					string date = Console.ReadLine();

					Console.WriteLine("Please Enter Item Priority Level of High, Normal, or Low: ");
					string priority = Console.ReadLine();

					ToDoList item = new ToDoList(description, date, priority);
					ToDoListings.Add(item);

					Console.WriteLine("Would You Like to Add Anoter Item? Yes/No");
					string secondChoice = Console.ReadLine().ToLower();
					Console.WriteLine("\n");
					if (secondChoice == "no")
					{
						break;
					}
				}
			}

			public static void OutPut()
			{
				int count = 0;

				Console.WriteLine("To Do List \n");
				Console.WriteLine("Description | " + "Due Date |" + " Priority");
				Console.WriteLine("---------------------------------");
				foreach (ToDoList item in ToDoListings)
				{
					count += 1;
					Console.WriteLine(count + ") " + item.Description + " | " + item.DueDate + " | " + item.Priority);
				}
			}
		}
	}
}