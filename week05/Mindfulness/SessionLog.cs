using System;

public static class SessionLog
{
    private static readonly Dictionary<string, int> _activityCounts = new Dictionary<string, int>();
    private static int _totalSeconds = 0;

    public static void Record(string activityName, int duration)
    {
        if (!_activityCounts.ContainsKey(activityName))
        {
            _activityCounts[activityName] = 0;
        }

        _activityCounts[activityName]++;
        _totalSeconds += duration;
    }

    public static void DisplaySummary()
    {
        Console.Clear();
        Console.WriteLine("Session Summary");
        Console.WriteLine();

        if (_activityCounts.Count == 0)
        {
            Console.WriteLine("No activities completed yet this session.");
        }
        else
        {
            Console.WriteLine($"Total mindful seconds: {_totalSeconds}");
            Console.WriteLine($"Total activities completed: {GetTotalActivities()}");
            Console.WriteLine();

            foreach (KeyValuePair<string, int> entry in _activityCounts)
            {
                Console.WriteLine($"{entry.Key} sessions: {entry.Value}");
            }
        }

        Console.WriteLine();
        Console.WriteLine("Press enter to return to the menu.");
        Console.ReadLine();
    }

    private static int GetTotalActivities()
    {
        int total = 0;

        foreach (int count in _activityCounts.Values)
        {
            total += count;
        }

        return total;
    }
}
