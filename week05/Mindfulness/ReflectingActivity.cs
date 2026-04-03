using System;

public class ReflectingActivity : Activity
{
    private readonly Random _random = new Random();
    private readonly List<string> _prompts;
    private readonly List<string> _questions;
    private readonly List<string> _unusedPrompts;
    private readonly List<string> _unusedQuestions;

    public ReflectingActivity()
        : base(
            "Reflecting",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.",
            30)
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        _unusedPrompts = new List<string>(_prompts);
        _unusedQuestions = new List<string>(_questions);
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine();
        DisplayPrompt();
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);

        DisplayQuestions();
        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        return GetRandomItem(_unusedPrompts, _prompts);
    }

    public string GetRandomQuestion()
    {
        return GetRandomItem(_unusedQuestions, _questions);
    }

    public void DisplayPrompt()
    {
        string currentPrompt = GetRandomPrompt();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine($"--- {currentPrompt} ---");
    }

    public void DisplayQuestions()
    {
        DateTime endTime = DateTime.Now.AddSeconds(Duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine($"> {GetRandomQuestion()}");
            ShowSpinner(5);
        }
    }

    private string GetRandomItem(List<string> availableItems, List<string> sourceItems)
    {
        if (availableItems.Count == 0)
        {
            availableItems.AddRange(sourceItems);
        }

        int index = _random.Next(availableItems.Count);
        string item = availableItems[index];
        availableItems.RemoveAt(index);
        return item;
    }
}
