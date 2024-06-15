using System;
using System.IO;

public abstract class MindfulnessActivity
{
    // Protected member variables to be shared among derived classes
    protected string _name;
    protected string _description;
    protected int _duration;

    // Constructor to initialize the common attributes
    public MindfulnessActivity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    // Method to start the activity
    public void Start()
    {
        Console.Clear(); // Clear the console
        Console.WriteLine($"Starting {_name}...");
        Console.WriteLine(_description);
        Console.Write("\nEnter the duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("\nPrepare to begin...");
        ShowAnimation(3); // Pause for 3 seconds with animation
        PerformActivity(); // Perform the specific activity
        End(); // End the activity
    }

    // Abstract method to be implemented by derived classes for specific activity behavior
    protected abstract void PerformActivity();

    // Method to end the activity
    protected void End()
    {
        Console.Clear(); // Clear the console
        Console.WriteLine("Good job!");
        Console.WriteLine($"You have completed the {_name} activity for {_duration} seconds.");
        ShowAnimation(3); // Pause for 3 seconds with animation
        LogActivity(_name); // Log the completion of the activity
    }

    // Method to show an animation (simple countdown with periods)
    protected void ShowAnimation(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            System.Threading.Thread.Sleep(1000); // 1 second delay
        }
        Console.WriteLine();
    }

    // Method to log the completion of an activity
    protected static void LogActivity(string activityName)
    {
        string logPath = "activity_log.csv";
        if (!File.Exists(logPath))
        {
            File.WriteAllText(logPath, "Activity,Count\n");
        }

        string[] lines = File.ReadAllLines(logPath);
        bool activityExists = false;
        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(',');
            if (parts[0] == activityName)
            {
                int count = int.Parse(parts[1]);
                count++;
                lines[i] = $"{activityName},{count}";
                activityExists = true;
                break;
            }
        }

        if (!activityExists)
        {
            File.AppendAllText(logPath, $"{activityName},1\n");
        }
        else
        {
            File.WriteAllLines(logPath, lines);
        }
    }
}
