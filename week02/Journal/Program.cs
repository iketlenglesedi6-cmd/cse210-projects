using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Creativity (exceeds requirements): a daily quote is shown, moods are picked from a friendly list,
        // and entries show a preview after writing.
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        QuoteGenerator quoteGenerator = new QuoteGenerator();
        string projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));

        bool keepRunning = true;
        while (keepRunning)
        {
            Console.WriteLine();
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Random Review");
            Console.WriteLine("6. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine() ?? "";
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Quote of the moment:");
                    Console.WriteLine($"\"{quoteGenerator.GetRandomQuote()}\"");
                    Console.WriteLine();
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    Console.Write("> ");
                    string response = Console.ReadLine() ?? "";
                    Console.WriteLine("Pick your mood:");
                    string[] moods = { "happy", "tired", "stressed", "peaceful", "excited", "grateful", "anxious" };
                    for (int i = 0; i < moods.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}. {moods[i]}");
                    }
                    Console.Write("Mood (1-7, or press Enter to skip): ");
                    string moodInput = Console.ReadLine() ?? "";
                    string mood = "N/A";
                    if (!string.IsNullOrWhiteSpace(moodInput))
                    {
                        if (int.TryParse(moodInput.Trim(), out int moodIndex) && moodIndex >= 1 && moodIndex <= moods.Length)
                        {
                            mood = moods[moodIndex - 1];
                        }
                        else
                        {
                            mood = moodInput.Trim();
                        }
                    }
                    Console.Write("Tags (comma-separated, or press Enter to skip): ");
                    string tagsInput = Console.ReadLine() ?? "";
                    string tags = string.IsNullOrWhiteSpace(tagsInput) ? "" : tagsInput.Trim();
                    string date = DateTime.Now.ToShortDateString();
                    Entry entry = new Entry(date, prompt, response, mood, tags);
                    journal.AddEntry(entry);
                    Console.WriteLine();
                    Console.WriteLine("Entry preview:");
                    entry.Display();
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    break;
                case "2":
                    journal.DisplayAll();
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    break;
                case "3":
                    Console.Write("What is the filename? ");
                    string loadFileInput = Console.ReadLine() ?? "";
                    string loadFileName = string.IsNullOrWhiteSpace(loadFileInput) ? "journal.txt" : loadFileInput.Trim();
                    if (!Path.HasExtension(loadFileName))
                    {
                        loadFileName += ".txt";
                    }
                    string loadPath = Path.Combine(projectRoot, loadFileName);
                    journal.LoadFromFile(loadPath);
                    Console.WriteLine($"Loaded from: {loadPath}");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    break;
                case "4":
                    Console.Write("What is the filename? ");
                    string saveFileInput = Console.ReadLine() ?? "";
                    string saveFileName = string.IsNullOrWhiteSpace(saveFileInput) ? "journal.txt" : saveFileInput.Trim();
                    if (!Path.HasExtension(saveFileName))
                    {
                        saveFileName += ".txt";
                    }
                    string savePath = Path.Combine(projectRoot, saveFileName);
                    journal.SaveToFile(savePath);
                    Console.WriteLine($"Saved to: {savePath}");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    break;
                case "5":
                    journal.DisplayRandomEntry();
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    break;
                case "6":
                    keepRunning = false;
                    Console.WriteLine("Thank you for sharing your emotions. Goodbye.");
                    break;
                default:
                    Console.WriteLine("Please enter a number from 1 to 6.");
                    break;
            }
        }
    }
}
