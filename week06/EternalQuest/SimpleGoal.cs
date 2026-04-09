public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string shortName, string description, int points, bool isComplete = false)
        : base(shortName, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        if (_isComplete)
        {
            return 0;
        }

        _isComplete = true;
        return Points;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStatusText()
    {
        string checkbox = _isComplete ? "[X]" : "[ ]";
        return $"{checkbox} {ShortName} ({Description})";
    }

    public override string GetSaveData()
    {
        return $"SimpleGoal|{ShortName}|{Description}|{Points}|{_isComplete}";
    }
}
