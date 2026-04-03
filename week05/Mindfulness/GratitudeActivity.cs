using System;

public class GratitudeActivity : Activity
{
    private readonly Random _random = new Random();
    private readonly List<string> _prompts;

    public GratitudeActivity()
        : base(
            "Gratitude",
            "This activity will help you slow down and notice small blessings by writing short gratitude statements one at a time.",
            30)
    {
        _prompts = new List<string>
        {
            "Name a person you are thankful for today.",
            "Name a simple comfort you enjoyed recently.",
            "Name something about your body that helps you each day.",
            "Name a place that helps you feel calm.",
            "Name a recent moment that made you smile."
        };
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        int entryNumber = 1;

        Console.WriteLine();
        Console.WriteLine("Write one gratitude note for each prompt that appears.");
        Console.WriteLine();

        while (DateTime.Now < endTime)
        {
            Console.WriteLine($"Prompt {entryNumber}: {GetRandomPrompt()}");
            Console.Write("> ");
            Console.ReadLine();

            if (DateTime.Now < endTime)
            {
                Console.WriteLine("Take a breath and notice that good thing.");
                ShowSpinner(2);
                Console.WriteLine();
            }

            entryNumber++;
        }

        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        return _prompts[_random.Next(_prompts.Count)];
    }
}
