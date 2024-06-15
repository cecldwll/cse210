// Showing Creativity and Exceeding Requirements:
//     Added the ability to save and load a log file containing the activity data.

using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear(); // Clear the console
            // Display the menu to the user
            Console.WriteLine("Select an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");

            // Read user choice
            int choice = int.Parse(Console.ReadLine());
            MindfulnessActivity activity = null;

            // Create the appropriate activity based on user choice
            switch (choice)
            {
                case 1:
                    activity = new BreathingActivity();
                    break;
                case 2:
                    activity = new ReflectionActivity();
                    break;
                case 3:
                    activity = new ListingActivity();
                    break;
                case 4:
                    return; // Exit the program
                default:
                    Console.WriteLine("Invalid choice. Please select again.");
                    continue;
            }

            // Start the selected activity
            activity.Start();
        }
    }
}
