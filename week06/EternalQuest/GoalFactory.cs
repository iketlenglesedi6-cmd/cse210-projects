using System;

public static class GoalFactory
{
    public static Goal CreateGoalFromUserInput()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.WriteLine("  4. Milestone Goal");
        Console.Write("Which type of goal would you like to create? ");
        int choice = InputHelper.ReadMenuChoice(1, 4);

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine() ?? "";
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine() ?? "";
        Console.Write("How many points will it be worth? ");
        int points = InputHelper.ReadPositiveInt();

        if (choice == 1)
        {
            return new SimpleGoal(name, description, points);
        }

        if (choice == 2)
        {
            return new EternalGoal(name, description, points);
        }

        if (choice == 3)
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int targetCount = InputHelper.ReadPositiveInt();
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = InputHelper.ReadPositiveInt();
            return new ChecklistGoal(name, description, points, bonus, targetCount);
        }

        Console.Write("What total amount of progress is needed to finish this goal? ");
        int targetAmount = InputHelper.ReadPositiveInt();
        Console.Write("What bonus should be awarded when this goal is completed? ");
        int completionBonus = InputHelper.ReadPositiveInt();
        return new MilestoneGoal(name, description, points, targetAmount, completionBonus);
    }

    public static Goal CreateGoalFromSaveData(string data)
    {
        string[] parts = data.Split("|");
        string type = parts[0];

        if (type == "SimpleGoal")
        {
            return new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4]));
        }

        if (type == "EternalGoal")
        {
            return new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
        }

        if (type == "ChecklistGoal")
        {
            return new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]));
        }

        if (type == "MilestoneGoal")
        {
            return new MilestoneGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]));
        }

        throw new InvalidOperationException("Unknown goal type in save file.");
    }
}
