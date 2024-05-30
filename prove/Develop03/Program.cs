using System;

namespace ScriptureMemorizer
{
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
                // Display menu options
                Console.Clear();
                Console.WriteLine("1. Input new scripture");
                Console.WriteLine("2. Load scripture from file");
                Console.WriteLine("3. Quit");
                string choice = Console.ReadLine();

                // Handle user's menu choice
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

                // Loop to display and hide words in the scripture
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
                        if (scripture.AllWordsHidden())
                        {
                            Console.Clear();
                            Console.WriteLine("All words are hidden!");
                            break;
                        }
                    }
                }
            }
        }
    }
}
