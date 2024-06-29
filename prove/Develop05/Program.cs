
//  * Showing Creativity and Exceeding Requirements:
//  * 
//  * 1. Leveling Up System: Users level up after reaching certain score thresholds. Each level gives a badge.
//  * 2. Badges and Achievements: Users earn badges upon leveling up.
//  * 3. Negative Goals: Users can set goals where they



using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Goal> goals = new List<Goal>();
    static int totalScore = 0;
    static int level = 1;
    static List<string> badges = new List<string>();

    static void Main(string[] args)
    {
        LoadGoals();
        string choice;
        do
        {
            Console.Clear();
            Console.WriteLine("Eternal Quest");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Display Goals");
            Console.WriteLine("4. Display Score");
            Console.WriteLine("5. Save and Exit");
            Console.Write("Select an option: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateNewGoal();
                    break;
                case "2":
                    RecordEvent();
                    break;
                case "3":
                    DisplayGoals();
                    break;
                case "4":
                    DisplayScore();
                    break;
                case "5":
                    SaveGoals();
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }

        } while (choice != "5");
    }

    static void CreateNewGoal()
    {
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Negative Goal");
        Console.WriteLine("5. Progress Goal");
        Console.Write("Select goal type: ");
        string type = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();
        Console.Write("Enter goal points: ");
        int points = int.Parse(Console.ReadLine());

        Goal goal = null;

        switch (type)
        {
            case "1":
                goal = new SimpleGoal(name, description, points);
                break;
            case "2":
                goal = new EternalGoal(name, description, points);
                break;
            case "3":
                Console.Write("Enter target count: ");
                int targetCount = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonusPoints = int.Parse(Console.ReadLine());
                goal = new ChecklistGoal(name, description, points, targetCount, bonusPoints);
                break;
            case "4":
                goal = new NegativeGoal(name, description, points);
                break;
            case "5":
                Console.Write("Enter target progress: ");
                int targetProgress = int.Parse(Console.ReadLine());
                Console.Write("Enter progress points: ");
                int progressPoints = int.Parse(Console.ReadLine());
                goal = new ProgressGoal(name, description, points, targetProgress, progressPoints);
                break;
            default:
                Console.WriteLine("Invalid goal type. Goal not created.");
                return;
        }

        goals.Add(goal);
        Console.WriteLine("Goal created successfully.");
    }

    static void RecordEvent()
    {
        DisplayGoals();
        Console.Write("Enter the goal number to record an event: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < goals.Count)
        {
            Goal goal = goals[index];
            goal.RecordEvent();
            totalScore += goal.Points;
            LevelUp();
            Console.WriteLine("Event recorded successfully.");
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    static void DisplayGoals()
    {
        Console.WriteLine("Goals:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetStatus()} {goals[i].Name} - {goals[i].Description}");
        }
    }

    static void DisplayScore()
    {
        Console.WriteLine($"Total Score: {totalScore}");
        Console.WriteLine($"Level: {level}");
        Console.WriteLine("Badges:");
        foreach (var badge in badges)
        {
            Console.WriteLine($"- {badge}");
        }
    }

    static void LevelUp()
    {
        int levelThreshold = 1000 * level;
        if (totalScore >= levelThreshold)
        {
            level++;
            badges.Add($"Level {level} Achieved!");
            Console.WriteLine($"Congratulations! You've reached level {level}!");
        }
    }

    static void SaveGoals()
    {
        using (StreamWriter outputFile = new StreamWriter("goals.txt"))
        {
            outputFile.WriteLine(totalScore);
            outputFile.WriteLine(level);
            outputFile.WriteLine(string.Join(",", badges));
            foreach (Goal goal in goals)
            {
                outputFile.WriteLine(goal.Serialize());
            }
        }
    }

    static void LoadGoals()
    {
        if (File.Exists("goals.txt"))
        {
            string[] lines = File.ReadAllLines("goals.txt");
            totalScore = int.Parse(lines[0]);
            level = int.Parse(lines[1]);
            badges = new List<string>(lines[2].Split(','));

            for (int i = 3; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(":");
                string type = parts[0];
                string[] details = parts[1].Split(",");

                Goal goal = null;

                switch (type)
                {
                    case "SimpleGoal":
                        goal = new SimpleGoal(details[0], details[1], int.Parse(details[2]));
                        goal.SetCompletionStatus(bool.Parse(details[3]));
                        break;
                    case "EternalGoal":
                        goal = new EternalGoal(details[0], details[1], int.Parse(details[2]));
                        break;
                    case "ChecklistGoal":
                        goal = new ChecklistGoal(details[0], details[1], int.Parse(details[2]), int.Parse(details[4]), int.Parse(details[5]));
                        ((ChecklistGoal)goal).SetCurrentCount(int.Parse(details[3]));
                        goal.SetCompletionStatus(bool.Parse(details[6]));
                        break;
                    case "NegativeGoal":
                        goal = new NegativeGoal(details[0], details[1], int.Parse(details[2]));
                        goal.SetCompletionStatus(bool.Parse(details[3]));
                        break;
                    case "ProgressGoal":
                        goal = new ProgressGoal(details[0], details[1], int.Parse(details[2]), int.Parse(details[4]), int.Parse(details[5]));
                        ((ProgressGoal)goal).SetCurrentProgress(int.Parse(details[3]));
                        goal.SetCompletionStatus(bool.Parse(details[6]));
                        break;
                }

                goals.Add(goal);
            }
        }
    }
}
