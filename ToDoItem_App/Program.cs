using System;

namespace ToDoItem_App
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleUtil ToDo = new ConsoleUtil();
            ToDo.Run();
            Console.Read();
        }
    }
}
