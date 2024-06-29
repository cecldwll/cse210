using System;

class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
    }

    public override void RecordEvent()
    {
        // No completion state for eternal goals, just accumulate points
    }

    public override string GetStatus()
    {
        return "[ ]"; // Eternal goals never complete
    }

    public override string Serialize()
    {
        return $"EternalGoal:{Name},{Description},{Points}";
    }
}
