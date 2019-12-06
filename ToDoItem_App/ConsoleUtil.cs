using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoItem_App
{
    class ConsoleUtil
    {
        public App App;
        public UserInput Choice { get; set; }

        //Is used by Run();
        protected bool run = true;

        string message = "";

        //constructor
        public ConsoleUtil()
        {
            App = new App();
            Console.WriteLine("Hello. Welcome to your To Do List. Please select from the following options:");
        }

        #region Run
        //Loop so that users have more than two chances to input correct options
        public void Run()
        {
            while(run == true)
            {
                takeInput();
            }
        }
        #endregion

        #region Loop for Taking Input
        //if input was not valid display menu again and get input again
        //if input was valid then process the input
        public void takeInput()
        {
            if (!DisplayMenu())
            {
                DisplayMenu();
            }
            else
            {
                ProcessInput();
            }
        }
        #endregion

        #region Validate
        public bool Validation(string input)
        {
            //is input empty
            if(String.IsNullOrEmpty(input))
            {
                return false;
            }

            //is any index of the array empty
            string[] inputParts = input.Split('|');
            for (int i = 0; i<inputParts.Length; i++)
            {
                if(string.IsNullOrEmpty(inputParts[i]))
                {
                    return false;
                }
            }

            //check for ability to convert to correct type
            //delete item first
            //adding Item second
            //updating item third
            if(inputParts.Length == 1)
            {
                try
                {
                    int.Parse(inputParts[0]);
                }
                catch
                {
                    return false;
                }
            }
            else if (inputParts.Length == 3)
            {
                try
                {
                    inputParts[0].ToString();
                    inputParts[1].ToString();
                    Convert.ToDateTime(inputParts[2]);
                }
                catch
                {
                    return false;
                }
            }
            else if(inputParts.Length == 4)
            {
                try
                {
                    int.Parse(inputParts[0]);
                    inputParts[1].ToString();
                    inputParts[2].ToString();
                    Convert.ToDateTime(inputParts[3]);
                }
                catch
                {
                    return false;
                }
            }
            
            return true;
        }
        #endregion

        #region Input Enum
        public enum UserInput
        {
            l,
            done,
            pending,
            a,
            u,
            d,
            q
        }
        #endregion

        #region Write Errors
        static void WriteError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine(message);
            Console.ResetColor();
        }
        #endregion

        #region Display Menu
        public bool DisplayMenu()
        {
            string menu = @"
             List All Items: L/l
             List Items According to Status: done/pending
             Update an Item: U/u
             Add an Item: A/a
             Delete an Item: D/d
             Quit: Q/q";
            Console.WriteLine(menu);

            //try to convert user input into enum type
            // catch exception and return false otherwise
            try
            {
                Choice = (UserInput)Enum.Parse(typeof(UserInput), Console.ReadLine().ToLower());

                return true;
            }
            catch
            {
                message = "You did not input a valid menu option. Please try again.";
                WriteError(message);
                return false;
            }
        }
        #endregion

        #region Print
        //Print the Item Objects
        public void PrintList(List<ToDoItem> list)
        {
            if (list != null)
            {
                Console.WriteLine("To Do List:");
                foreach (ToDoItem item in list)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($@"
    [Item ID: {item.ID}
    Description: {item.Description}
    Status: {item.Status}
    Due Date: {item.DueDate}]");
                }
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("There are currently no items to display.");
            }
        }
        #endregion

        #region Process Input
        public void ProcessInput()
        {
            while (Choice != UserInput.q)
            {
                switch (Choice)
                {
                        //Print List of All Items
                    case UserInput.l:
                        List<ToDoItem> allList = App.ListItems();
                        PrintList(allList);
                        break;

                        //Print List of Done Items
                    case UserInput.done:
                        List<ToDoItem> doneList = App.ListItems("done");
                        PrintList(doneList);
                        break;

                        //Print List of Pending Items
                    case UserInput.pending:
                        List<ToDoItem> pendingList = App.ListItems("pending");
                        PrintList(pendingList);
                        break;

                        //Add Item
                    case UserInput.a:
                        Console.WriteLine("Add and Item: Please provide information in the form-- description|status|dueDate(mm/dd/yyyy)");
                        string itemInfo = Console.ReadLine().Trim();

                        if(!Validation(itemInfo))
                        {
                            message = "Sorry you did not input something correctly.";
                            WriteError(message);
                        }
                        else
                        {
                            string[] parts = itemInfo.Split('|');
                            App.AddItem(parts[0], parts[1], Convert.ToDateTime(parts[2]));
                        }
                        break;

                        //Update Item
                    case UserInput.u:
                        Console.WriteLine("To update an item please provide the updated information as: ID|new description |new status|new duedate(mm/dd/yyyy)");
                        string updateInfo = Console.ReadLine().Trim();

                        if(!Validation(updateInfo))
                        {
                            message = "Sorry you did not input something correctly.";
                            WriteError(message);
                        }
                        else
                        {
                            string[] upParts = updateInfo.Split('|');

                            if(App.UpdateItem(int.Parse(upParts[0]), upParts[1], upParts[2], Convert.ToDateTime(upParts[3])) != null)
                            {
                                    Console.WriteLine("Your item has been updated.");    
                            }
                            else
                            {
                                message = "That item does not exist. You might look at the list again to select the correct item ID.";        
                                WriteError(message);
                            }
                        }
                        break; 
                    
                        //Delete Item
                    case UserInput.d:
                        Console.WriteLine("Please provide the ID of the item you would like to delete.");
                        string strId = Console.ReadLine();
                        if (!Validation(strId))
                        {
                            message = "That is an incorrect input. Please give IDs in the form of 1 2 3 etc...";
                            WriteError(message);
                        }
                        else
                        {
                            int id = int.Parse(strId);

                            if (App.DeleteItems(id) != null)
                            {
                                Console.WriteLine("Your item has been deleted");
                            }
                            else
                            {
                                message = "The item you selected does not exist. You might list the items again to find the correct ID";
                                WriteError(message);
                            }
                        }
                        
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("Pick Another Option...");
                DisplayMenu();
            }

            //User has chosen to quit
            run = false;
            Console.WriteLine("Have a great day!");
        }
#endregion
    }
}
