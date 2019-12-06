using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoItem_App
{
    class ToDoItem
    {
        public int ID { get; private set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime DueDate { get; set; }

        public ToDoItem(string Description, string Status, DateTime DueDate)
        {
            this.Description = Description;
            this.Status = Status;
            this.DueDate = DueDate;
        }
    }
}
