using System;
using System.Collections.Generic;
using System.Transactions;

namespace ToDoList
{
    public class ToDo
    {
        static void Main(string[] args) 
        {
            ToDo.ListItems();
        }
        public static void ListItems()
        {
            var toDoList = new List<string>();
            var appRunning = true;

            Console.WriteLine("Welcome to the simple todo list app\n");
            Console.WriteLine("Commands: '-Exit', '-Show', '-' \n ");

            while (appRunning == true)
            {
                Console.WriteLine("Please enter a list item to add or a command to perfrom: ");

                var input = Console.ReadLine();
                switch (input)
                {
                    case string a when a.StartsWith("-Exit"):
                        appRunning = false;
                        break;
                    case string b when b.EndsWith("-"):
                        var endIndex = b.IndexOf("-");
                        var item = b.Substring(0, endIndex);
                        if (toDoList.Contains(item))
                        {
                            toDoList.Remove(item);
                            Console.WriteLine("Removed {0} \n", item);

                        }
                        else
                        {
                            Console.WriteLine("{0} is not currently in the list, it cannnot be removed", item);
                        }
                        break;
                    case string c when c.StartsWith("-Show"):
                        Console.WriteLine("\n ----- TO DO LIST ----- \n");
                        foreach (var task in toDoList)
                        {
                            Console.WriteLine(task);
                        }
                        Console.WriteLine("------------------\n");
                        break;
                    default:
                        toDoList.Add(input);
                        break;
                }

            }
        }
    }
}