using System;
using System.Collections.Generic;

public static class QuestTheme
{
    private static readonly string[] _rankTitles =
    {
        "Seeker",
        "Pathfinder",
        "Disciplined Adventurer",
        "Steadfast Guardian",
        "Covenant Champion",
        "Eternal Hero"
    };

    public static void ShowBanner()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("         ETERNAL QUEST TRACKER");
        Console.WriteLine("========================================");
        Console.WriteLine();
    }

    public static string GetRankTitle(int level)
    {
        int index = Math.Min(level - 1, _rankTitles.Length - 1);
        return _rankTitles[index];
    }

    public static string GetCelebrationMessage(int earnedPoints)
    {
        if (earnedPoints >= 1000)
        {
            return "Legendary work. That quest step was huge.";
        }

        if (earnedPoints >= 500)
        {
            return "Epic progress. You are building real momentum.";
        }

        if (earnedPoints >= 100)
        {
            return "Nice work. Another meaningful win added to the journey.";
        }

        return "Small steps still count. Progress is progress.";
    }

    public static List<string> GetBadges(int score, int totalGoals, int completedGoals)
    {
        List<string> badges = new List<string>();

        if (score >= 500)
        {
            badges.Add("Spark of Momentum");
        }

        if (score >= 1000)
        {
            badges.Add("Level Breaker");
        }

        if (totalGoals >= 3)
        {
            badges.Add("Quest Builder");
        }

        if (completedGoals >= 1)
        {
            badges.Add("Promise Keeper");
        }

        if (completedGoals >= 3)
        {
            badges.Add("Finisher");
        }

        return badges;
    }
}
