using System;
using System.Collections.Generic;

public class ListingActivity : MindfulnessActivity
{
    // Static array of prompts for listing
    private static readonly string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    // Constructor initializing the base class with name and description
    public ListingActivity() 
        : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    // Implementation of the PerformActivity method specific to the listing activity
    protected override void PerformActivity()
    {
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Length)]; // Select a random prompt
        Console.WriteLine(prompt);
        ShowAnimation(5); // 5-second countdown to begin listing

        List<string> items = new List<string>(); // List to store user inputs
        int elapsed = 0; // Track elapsed time
        while (elapsed < _duration)
        {
            Console.Write("Enter an item: ");
            string item = Console.ReadLine();
            items.Add(item); // Add user input to the list
            elapsed += 5; // Increase elapsed time by 5 seconds (assuming each entry takes approximately 5 seconds)
        }

        Console.WriteLine($"You listed {items.Count} items."); // Display the count of listed items
        System.Threading.Thread.Sleep(5000); // Pause for 5 seconds (5000 milliseconds)
    }
}
