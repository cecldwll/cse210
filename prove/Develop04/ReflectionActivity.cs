using System;

public class ReflectionActivity : MindfulnessActivity
{
    // Static arrays of prompts and questions for reflection
    private static readonly string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static readonly string[] questions = {
        "\nWhy was this experience meaningful to you?",
        "\nHave you ever done anything like this before?",
        "\nHow did you get started?",
        "\nHow did you feel when it was complete?",
        "\nWhat made this time different than other times when you were not as successful?",
        "\nWhat is your favorite thing about this experience?",
        "\nWhat could you learn from this experience that applies to other situations?",
        "\nWhat did you learn about yourself through this experience?",
        "\nHow can you keep this experience in mind in the future?"
    };

    // Constructor initializing the base class with name and description
    public ReflectionActivity() 
        : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    // Implementation of the PerformActivity method specific to the reflection activity
    protected override void PerformActivity()
    {
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Length)]; // Select a random prompt
        Console.WriteLine(prompt);

        int elapsed = 0; // Track elapsed time
        while (elapsed < _duration)
        {
            string question = questions[random.Next(questions.Length)]; // Select a random question
            Console.WriteLine(question);
            ShowAnimation(5); // 5-second pause to reflect on each question
            elapsed += 5; // Increase elapsed time by the duration of each question reflection
        }
    }
}