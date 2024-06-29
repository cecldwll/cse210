using System;

class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
        IsCompleted = false;
    }

    public override void RecordEvent()
    {
        if (!IsCompleted)
        {
            IsCompleted = true;
        }
    }

    public override string GetStatus()
    {
        return IsCompleted ? "[X]" : "[ ]";
    }

    public override string Serialize()
    {
        return $"SimpleGoal:{Name},{Description},{Points},{IsCompleted}";
    }
}
