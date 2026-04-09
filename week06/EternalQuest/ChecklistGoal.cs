public class ChecklistGoal : Goal
{
    private int _bonus;
    private int _amountCompleted;
    private int _targetCount;

    public ChecklistGoal(string shortName, string description, int points, int bonus, int targetCount, int amountCompleted = 0)
        : base(shortName, description, points)
    {
        _bonus = bonus;
        _targetCount = targetCount;
        _amountCompleted = amountCompleted;
    }

    public override int RecordEvent()
    {
        if (IsComplete())
        {
            return 0;
        }

        _amountCompleted++;

        if (_amountCompleted >= _targetCount)
        {
            return Points + _bonus;
        }

        return Points;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _targetCount;
    }

    public override string GetStatusText()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {ShortName} ({Description}) -- Completed {_amountCompleted}/{_targetCount} times";
    }

    public override string GetSaveData()
    {
        return $"ChecklistGoal|{ShortName}|{Description}|{Points}|{_bonus}|{_targetCount}|{_amountCompleted}";
    }
}
