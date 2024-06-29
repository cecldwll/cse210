using System;

class ProgressGoal : Goal
{
    public int TargetProgress { get; private set; }
    public int CurrentProgress { get; private set; }
    public int ProgressPoints { get; private set; }

    public ProgressGoal(string name, string description, int points, int targetProgress, int progressPoints)
        : base(name, description, points)
    {
        TargetProgress = targetProgress;
        ProgressPoints = progressPoints;
        CurrentProgress = 0;
    }

    public override void RecordEvent()
    {
        CurrentProgress++;
        Points += ProgressPoints;
        if (CurrentProgress >= TargetProgress)
        {
            IsCompleted = true;
            Console.WriteLine($"Goal completed: {Name}. Earned total of {Points} points.");
        }
        else
        {
            Console.WriteLine($"Progress recorded: {Name}. Current progress: {CurrentProgress}/{TargetProgress}. Earned {ProgressPoints} points.");
        }
    }

    public override string GetStatus()
    {
        return IsCompleted ? "[X]" : $"[ ] (Progress: {CurrentProgress}/{TargetProgress})";
    }

    public override string Serialize()
    {
        return $"ProgressGoal:{Name},{Description},{Points},{CurrentProgress},{TargetProgress},{ProgressPoints},{IsCompleted}";
    }

    internal void SetCurrentProgress(int v)
    {
        throw new NotImplementedException();
    }
}
