using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Menu();
    }

    public static void Menu()
    {
        GetScripture getScripture = new GetScripture();
        LoadScripture loadScripture = new LoadScripture();
        Scripture scripture = null;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("1. Input new scripture");
            Console.WriteLine("2. Load scripture from file");
            Console.WriteLine("3. Quit");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                scripture = loadScripture.Load(getScripture);
            }
            else if (choice == "2")
            {
                scripture = getScripture.LoadFromFile();
            }
            else if (choice == "3")
            {
                break;
            }

            if (scripture != null)
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine(scripture.Display());
                    Console.WriteLine("\nPress Enter to continue, type 'save' to save, or type 'quit' to end.");
                    string input = Console.ReadLine();

                    if (input.ToLower() == "quit")
                        break;
                    else if (input.ToLower() == "save")
                    {
                        getScripture.Save(scripture);
                        break;
                    }

                    scripture.HideRandomWords();
                }
            }
        }
    }
}
