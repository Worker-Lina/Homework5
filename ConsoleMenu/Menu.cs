using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleMenu
{
    public class Menu
    {
        string[] items;

        public Menu() { }
        public Menu(string[] items)
        {
            this.items = items;
        }


        public void Input(string[] items)
        {
            this.items = items;
        }

        public void Print()
        {
            Console.WriteLine("\n\n\n\t\t-----------Меню--------------");
            for (int i = 0; i < items.Length; i++)
            {
                Console.WriteLine($"\t\t\t{i + 1}. {items[i]}");
            }
            Console.Write("\n\t -->");
        }
    }
}
