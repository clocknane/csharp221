using System;
using System.Linq;
using System.Collections.Generic;

namespace Book_Inventory
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			BookContext context = new BookContext();
			context.Database.EnsureCreated();

			addBook(context);
			printInventory(context);

			IEnumerable<Book> book = context.books.OrderBy(x => x.Title);
			foreach (Book b in book)
			{
				Console.WriteLine($"{b.ID} - {b.Title} by {b.Author}");
			}

			IEnumerable<Book> authbook = context.books.OrderBy(x => x.Author);
			foreach (Book b in authbook)
			{
				Console.WriteLine($"{b.ID} - {b.Title} by {b.Author}");
			}

			Console.WriteLine("Do you want to delete a book? Y/N");
			string delete = Console.ReadLine().ToLower();
		}

		#region Input

		public static void GetInput(ref string title, ref string author)
		{
			Console.WriteLine("Please enter a book Title: ");
			title = Console.ReadLine();
			Console.WriteLine("Please enter the book's Author: ");
			author = Console.ReadLine();
		}

		#endregion Input

		#region Add

		private static void addBook(BookContext context)
		{
			Console.WriteLine("Would you like to add a book to your inventory? Y/N");
			string input = Console.ReadLine().ToLower();

			while (input != "n")
			{
				string title = "";
				string author = "";

				GetInput(ref title, ref author);

				Book newBook = new Book(title, author);

				context.books.Add(newBook);
				context.SaveChanges();

				Console.WriteLine("Would you like to add a book to your inventory? Y/N");
				input = Console.ReadLine().ToLower();
			}
		}

		#endregion Add

		#region Print

		public static void printInventory(BookContext context)
		{
			foreach (Book b in context.books)
			{
				Console.WriteLine();
				Console.WriteLine($"[{b.ID}\n{b.Title}\n{b.Author}]");
			}
		}

		#endregion Print
	}
}