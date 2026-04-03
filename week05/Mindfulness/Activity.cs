using System;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;
    private readonly List<string> _spinnerFrames = new List<string> { "|", "/", "-", "\\" };
    protected string Name => _name;
    protected string Description => _description;
    protected int Duration => _duration;

    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {Name} Activity.");
        Console.WriteLine();
        Console.WriteLine(Description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = ReadPositiveInt();

        Console.WriteLine();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        SessionLog.Record(Name, Duration);
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        Console.WriteLine();
        Console.WriteLine($"You have completed another {Duration} seconds of the {Name} Activity.");
        ShowSpinner(3);
    }

    public void ShowSpinner(int seconds)
    {
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int frameIndex = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(_spinnerFrames[frameIndex]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            frameIndex = (frameIndex + 1) % _spinnerFrames.Count;
        }

        Console.WriteLine();
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
            Console.Write("\r");
        }

        Console.WriteLine();
    }

    private int ReadPositiveInt()
    {
        while (true)
        {
            string input = Console.ReadLine();

            if (int.TryParse(input, out int duration) && duration > 0)
            {
                return duration;
            }

            Console.Write("Please enter a positive whole number: ");
        }
    }
}
