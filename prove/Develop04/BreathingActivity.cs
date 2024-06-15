using System;

public class BreathingActivity : MindfulnessActivity
{
    // Constructor initializing the base class with name and description
    public BreathingActivity() 
        : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    // Implementation of the PerformActivity method specific to the breathing activity
    protected override void PerformActivity()
    {
        int elapsed = 0; // Track elapsed time
        while (elapsed < _duration)
        {
            Console.WriteLine("\nBreathe in...");
            ShowAnimation(3); // 3-second countdown
            Console.WriteLine("\nBreathe out...");
            ShowAnimation(3); // 3-second countdown
            elapsed += 6; // Increase elapsed time by the duration of each breath cycle
        }
    }
}
