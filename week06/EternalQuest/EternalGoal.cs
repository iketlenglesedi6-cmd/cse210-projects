public class EternalGoal : Goal
{
    public EternalGoal(string shortName, string description, int points)
        : base(shortName, description, points)
    {
    }

    public override int RecordEvent()
    {
        return Points;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStatusText()
    {
        return $"[∞] {ShortName} ({Description})";
    }

    public override string GetSaveData()
    {
        return $"EternalGoal|{ShortName}|{Description}|{Points}";
    }
}
