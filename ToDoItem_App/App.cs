using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoItem_App
{
	internal class App
	{
		public ItemRepository Item { get; set; }

		public App()
		{
			Item = new ItemRepository();
		}

		public void AddItem(string description, string status, DateTime duedate)
		{
			Item.AddItem(description, status, duedate);
		}

		public List<ToDoItem> ListItems()
		{
			return Item.GetToDoItems();
		}

		public List<ToDoItem> ListItems(string filter)
		{
			return Item.GetToDoItems(filter);
		}

		public ToDoItem UpdateItem(int id, string newdescription, string newstatus, DateTime newduedate)
		{
			return Item.UpdateItem(id, newdescription, newstatus, newduedate);
		}

		public ToDoItem DeleteItems(int id)
		{
			return Item.DeleteItem(id);
		}
	}
}