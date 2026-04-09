using System;

public abstract class Goal
{
    private string _shortName;
    private string _description;
    private int _points;

    protected string ShortName => _shortName;
    protected string Description => _description;
    protected int Points => _points;

    protected Goal(string shortName, string description, int points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
    }

    public string GetShortName()
    {
        return _shortName;
    }

    public abstract int RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetStatusText();
    public abstract string GetSaveData();

    protected string GetStandardDetails()
    {
        return $"{_shortName},{_description},{_points}";
    }
}
