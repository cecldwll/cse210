using System;

abstract class Goal
{
    protected Goal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
    }

    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public int Points { get; protected set; }
    public bool IsCompleted { get; protected set; }

    public abstract void RecordEvent();
    public abstract string GetStatus();
    public abstract string Serialize();

    public void SetCompletionStatus(bool status)
    {
        IsCompleted = status;
    }
}
