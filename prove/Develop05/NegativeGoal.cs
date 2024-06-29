using System;

class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int points) : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        IsCompleted = true;
        Points = -Points; // Negative points
        Console.WriteLine($"Recorded: {Name}. Lost {Points} points.");
    }

    public override string GetStatus()
    {
        return IsCompleted ? "[X]" : "[ ]";
    }

    public override string Serialize()
    {
        return $"NegativeGoal:{Name},{Description},{Points},{IsCompleted}";
    }
}
