using System;

public static class InputHelper
{
    public static int ReadPositiveInt()
    {
        while (true)
        {
            string input = Console.ReadLine() ?? "";

            if (int.TryParse(input, out int value) && value > 0)
            {
                return value;
            }

            Console.Write("Please enter a positive whole number: ");
        }
    }

    public static int ReadMenuChoice(int min, int max)
    {
        while (true)
        {
            string input = Console.ReadLine() ?? "";

            if (int.TryParse(input, out int value) && value >= min && value <= max)
            {
                return value;
            }

            Console.Write($"Please enter a number from {min} to {max}: ");
        }
    }
}
