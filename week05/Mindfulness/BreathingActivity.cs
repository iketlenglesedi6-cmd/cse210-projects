using System;

public class BreathingActivity : Activity
{
    private const int InhaleSeconds = 4;
    private const int ExhaleSeconds = 6;

    public BreathingActivity()
        : base(
            "Breathing",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.",
            30)
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(Duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            AnimateBreath("Breathe in...", InhaleSeconds, expanding: true);

            if (DateTime.Now >= endTime)
            {
                break;
            }

            AnimateBreath("Breathe out...", ExhaleSeconds, expanding: false);
        }

        DisplayEndingMessage();
    }

    private void AnimateBreath(string label, int seconds, bool expanding)
    {
        for (int i = 0; i < seconds; i++)
        {
            int dots = expanding ? i + 1 : seconds - i;
            string visual = new string('o', dots);
            int remaining = seconds - i;

            Console.Write($"\r{label} {visual,-6} {remaining} ");
            Thread.Sleep(1000);
        }

        Console.WriteLine();
    }
}
