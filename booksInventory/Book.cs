using System;
using System.Collections.Generic;
using System.Text;

namespace Book_Inventory
{
	class Book
	{
		//fields/ properties for title and author
		public int ID { get; private set; }
		public string Title { get; set; }
		public string Author { get; set; }

		//constructor
		public Book(string Title, string Author)
		{
			this.Title = Title;
			this.Author = Author;
		}
	}
}