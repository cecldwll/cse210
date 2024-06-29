using System;

class ChecklistGoal : Goal
{
    public int TargetCount { get; }
    public int CurrentCount { get; private set; }
    public int BonusPoints { get; }

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
    {
        Name = name;
        Description = description;
        Points = points;
        TargetCount = targetCount;
        BonusPoints = bonusPoints;
        CurrentCount = 0;
        IsCompleted = false;
    }

    public void SetCurrentCount(int count)
    {
        CurrentCount = count;
    }

    public override void RecordEvent()
    {
        if (!IsCompleted)
        {
            CurrentCount++;
            if (CurrentCount >= TargetCount)
            {
                IsCompleted = true;
                Points += BonusPoints;
            }
        }
    }

    public override string GetStatus()
    {
        return IsCompleted ? "[X]" : $"[ ] Completed {CurrentCount}/{TargetCount} times";
    }

    public override string Serialize()
    {
        return $"ChecklistGoal:{Name},{Description},{Points},{CurrentCount},{TargetCount},{BonusPoints},{IsCompleted}";
    }
}
