 using System;

class Program
{
    // Creativity:
    // Prompts and reflection questions are not repeated until all items in that
    // session's list have been used once, which adds variety without changing the
    // required menu flow.
    // Added a Gratitude activity as an extra mindfulness option.
    // Added a session summary tracker that records completed activities and total
    // mindful seconds for the current run of the program.
    static void Main(string[] args)
    {
        string choice = "";

        while (choice != "6")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Start gratitude activity");
            Console.WriteLine("  5. View session summary");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine() ?? "";

            if (choice == "1")
            {
                BreathingActivity activity = new BreathingActivity();
                activity.Run();
            }
            else if (choice == "2")
            {
                ReflectingActivity activity = new ReflectingActivity();
                activity.Run();
            }
            else if (choice == "3")
            {
                ListingActivity activity = new ListingActivity();
                activity.Run();
            }
            else if (choice == "4")
            {
                GratitudeActivity activity = new GratitudeActivity();
                activity.Run();
            }
            else if (choice == "5")
            {
                SessionLog.DisplaySummary();
            }
            else if (choice != "6")
            {
                Console.WriteLine();
                Console.WriteLine("That is not a valid menu option.");
                Console.WriteLine("Press enter to continue.");
                Console.ReadLine();
            }
        }
    }
}
