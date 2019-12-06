using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ToDoItem_App
{
    class ItemContext : DbContext
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DirectoryInfo exeDirectory = new DirectoryInfo(AppContext.BaseDirectory);

            DirectoryInfo projectDirectory = exeDirectory.Parent.Parent.Parent;

            string DatabaseFile = Path.Combine(projectDirectory.FullName, "ToDoItems.db");

            optionsBuilder.UseSqlite("Data source = " + DatabaseFile);
        }
    }
}
