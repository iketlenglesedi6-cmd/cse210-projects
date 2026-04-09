using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private readonly List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start()
    {
        string choice = "";

        while (choice != "6")
        {
            DisplayPlayerInfo();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine() ?? "";

            Console.WriteLine();

            if (choice == "1")
            {
                CreateGoal();
            }
            else if (choice == "2")
            {
                ListGoalDetails();
            }
            else if (choice == "3")
            {
                SaveGoals();
            }
            else if (choice == "4")
            {
                LoadGoals();
            }
            else if (choice == "5")
            {
                RecordEvent();
            }
            else if (choice == "6")
            {
                Console.WriteLine("Good luck on your eternal quest!");
            }
            else
            {
                Console.WriteLine("That is not a valid option.");
            }

            if (choice != "6")
            {
                Pause();
            }
        }
    }

    private void DisplayPlayerInfo()
    {
        if (!Console.IsOutputRedirected)
        {
            Console.Clear();
        }

        QuestTheme.ShowBanner();
        Console.WriteLine($"Score: {_score} points");
        Console.WriteLine($"Level: {GetLevel()}");
        Console.WriteLine($"Rank: {QuestTheme.GetRankTitle(GetLevel())}");
        Console.WriteLine($"Quest Completion: {GetCompletionSummary()}");
        DisplayBadges();
        Console.WriteLine();
    }

    private int GetLevel()
    {
        return (_score / 1000) + 1;
    }

    private void CreateGoal()
    {
        Goal goal = GoalFactory.CreateGoalFromUserInput();
        _goals.Add(goal);
        Console.WriteLine();
        Console.WriteLine($"New quest added: {goal.GetShortName()}");
    }

    private void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }

        Console.WriteLine("Your active quests:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatusText()}");
        }
    }

    private void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("Create a goal before recording an event.");
            return;
        }

        Console.WriteLine("Choose a quest to record:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }

        Console.Write("Which goal did you accomplish? ");
        int selection = InputHelper.ReadMenuChoice(1, _goals.Count);
        Goal selectedGoal = _goals[selection - 1];
        int earnedPoints = selectedGoal.RecordEvent();

        if (earnedPoints == 0)
        {
            Console.WriteLine("This goal is already complete, so no additional points were awarded.");
            return;
        }

        int previousLevel = GetLevel();
        _score += earnedPoints;

        Console.WriteLine(QuestTheme.GetCelebrationMessage(earnedPoints));
        Console.WriteLine($"Congratulations! You have earned {earnedPoints} points.");
        Console.WriteLine($"You now have {_score} points.");

        if (GetLevel() > previousLevel)
        {
            Console.WriteLine($"Level up! You reached level {GetLevel()} - {QuestTheme.GetRankTitle(GetLevel())}.");
        }
    }

    private void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine() ?? "";

        List<string> lines = new List<string>
        {
            _score.ToString()
        };

        foreach (Goal goal in _goals)
        {
            lines.Add(goal.GetSaveData());
        }

        File.WriteAllLines(fileName, lines);
        Console.WriteLine("Quest log saved successfully.");
    }

    private void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine() ?? "";

        if (!File.Exists(fileName))
        {
            Console.WriteLine("That file could not be found.");
            return;
        }

        string[] lines = File.ReadAllLines(fileName);

        if (lines.Length == 0)
        {
            Console.WriteLine("That file is empty.");
            return;
        }

        _goals.Clear();
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            if (!string.IsNullOrWhiteSpace(lines[i]))
            {
                _goals.Add(GoalFactory.CreateGoalFromSaveData(lines[i]));
            }
        }

        Console.WriteLine("Quest log loaded successfully.");
    }

    private void Pause()
    {
        Console.WriteLine();
        Console.Write("Press enter to continue your quest.");
        Console.ReadLine();
    }

    private string GetCompletionSummary()
    {
        if (_goals.Count == 0)
        {
            return "0/0 complete";
        }

        int completedGoals = GetCompletedGoalCount();
        return $"{completedGoals}/{_goals.Count} complete";
    }

    private int GetCompletedGoalCount()
    {
        int completedGoals = 0;

        foreach (Goal goal in _goals)
        {
            if (goal.IsComplete())
            {
                completedGoals++;
            }
        }

        return completedGoals;
    }

    private void DisplayBadges()
    {
        List<string> badges = QuestTheme.GetBadges(_score, _goals.Count, GetCompletedGoalCount());

        if (badges.Count == 0)
        {
            Console.WriteLine("Badges: None yet");
            return;
        }

        Console.WriteLine($"Badges: {string.Join(", ", badges)}");
    }
}
