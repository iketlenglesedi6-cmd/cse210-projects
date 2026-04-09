public class MilestoneGoal : Goal
{
    private int _targetAmount;
    private int _currentAmount;
    private int _completionBonus;

    public MilestoneGoal(string shortName, string description, int points, int targetAmount, int completionBonus, int currentAmount = 0)
        : base(shortName, description, points)
    {
        _targetAmount = targetAmount;
        _completionBonus = completionBonus;
        _currentAmount = currentAmount;
    }

    public override int RecordEvent()
    {
        Console.Write("How much progress did you make on this goal? ");
        int progress = InputHelper.ReadPositiveInt();

        if (IsComplete())
        {
            return 0;
        }

        int remaining = _targetAmount - _currentAmount;
        int appliedProgress = Math.Min(progress, remaining);
        _currentAmount += appliedProgress;

        int earnedPoints = appliedProgress * Points;

        if (IsComplete())
        {
            earnedPoints += _completionBonus;
        }

        return earnedPoints;
    }

    public override bool IsComplete()
    {
        return _currentAmount >= _targetAmount;
    }

    public override string GetStatusText()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {ShortName} ({Description}) -- Progress {_currentAmount}/{_targetAmount}";
    }

    public override string GetSaveData()
    {
        return $"MilestoneGoal|{ShortName}|{Description}|{Points}|{_targetAmount}|{_completionBonus}|{_currentAmount}";
    }
}
