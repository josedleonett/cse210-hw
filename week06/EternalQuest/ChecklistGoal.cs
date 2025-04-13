public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string shortName, string description, int points, int target, int bonus) : base(shortName, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        if (IsComplete())
        {
            Console.WriteLine("This checklist goal is already complete. You cannot record more.");
            return;
        }

        _amountCompleted++;
        if (IsComplete())
        {
            Console.WriteLine($"Congratulations! You have completed the checklist goal and earned {_points + _bonus} points!");
        }
        else
        {
            Console.WriteLine($"Great job! You earned {_points} points!");
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailString()
    {
        return $"{(IsComplete() ? "[X]" : "[ ]")} {_shortName}: {_description} - Completed: {_amountCompleted}/{_target}";
    }
    
    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal,{_shortName},{_description},{_points},{_amountCompleted},{_target},{_bonus}";
    }
}