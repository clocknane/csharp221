using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Book_Inventory
{
	internal class BookContext : DbContext
	{
		public DbSet<Book> books { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			DirectoryInfo ExeDirectory = new DirectoryInfo(AppContext.BaseDirectory);

			DirectoryInfo ProjectBase = ExeDirectory.Parent.Parent.Parent;

			string DatabaseFile = Path.Combine(ProjectBase.FullName, "books.db");

			optionsBuilder.UseSqlite("Data Source=" + DatabaseFile);
		}
	}
}