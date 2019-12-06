using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDoItem_App
{
    class ItemRepository
    {
        ItemContext context;

        public ItemRepository()
        {
            context = new ItemContext();
            context.Database.EnsureCreated();
        }

        #region List All Items
        //List all my ToDo Items
        public List<ToDoItem> GetToDoItems()
        {
            IEnumerable<ToDoItem> list = context.ToDoItems;
            return list.ToList();
        }

        #endregion

        #region List Sorted by Filter
        public List<ToDoItem> GetToDoItems(string filter)
        {
            string lowFilter = filter.ToLower();
            if(lowFilter == "done")
            {
                IEnumerable<ToDoItem> list = context.ToDoItems.Where(item => item.Status == filter);
                return list.ToList();
            }
            else if(lowFilter == "pending")
            {
                IEnumerable<ToDoItem> list = context.ToDoItems.Where(item => item.Status == "pending");
                return list.ToList();
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region Add Item
        public void AddItem(string description, string status, DateTime duedate)
        {
            ToDoItem item = new ToDoItem(description, status, duedate);
            context.ToDoItems.Add(item);
            context.SaveChanges();
        }
        #endregion

        #region Update Item
        public ToDoItem UpdateItem(int id, string newDescription, string newStatus, DateTime newDueDate)
        {
            ToDoItem oldItem = context.ToDoItems.Where(item => item.ID == id).FirstOrDefault();

            if (oldItem != null)
            {
                oldItem.Description = newDescription;
                oldItem.Status = newStatus;
                oldItem.DueDate = newDueDate;
                context.Update(oldItem);
                context.SaveChanges();
                return oldItem;
            }
            else
            {
                return null;
            }
            
        }
        #endregion

        #region Delete Item
        public ToDoItem DeleteItem(int id)
        {
            ToDoItem delItem = context.ToDoItems.Where(item => item.ID == id).FirstOrDefault();

            if (delItem != null)
            {
                context.ToDoItems.Remove(delItem);
                context.SaveChanges();
                return delItem;
            }
            else
            {
                return null;
            }     
        }
        #endregion
    }
}
