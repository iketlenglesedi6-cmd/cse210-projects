using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        // Creativity: load scriptures from a file (with a safe fallback library),
        // randomly select one, and only hide words that are still visible.
        // Creativity: let the user pick a difficulty that controls how many words hide per step.
        // Creativity: optional auto-hide mode that hides words every few seconds.
        List<Scripture> library = LoadLibraryFromFile("scripture-library.txt");
        if (library.Count == 0)
        {
            library = BuildLibrary();
        }
        Random rng = new Random();

        Scripture scripture = library[rng.Next(library.Count)];

        int minHide = 2;
        int maxHide = 5;
        Console.Write("Choose difficulty (easy/medium/hard). Press Enter for medium: ");
        string difficulty = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(difficulty))
        {
            string normalized = difficulty.Trim().ToLower();
            if (normalized == "easy")
            {
                minHide = 1;
                maxHide = 3;
            }
            else if (normalized == "hard")
            {
                minHide = 4;
                maxHide = 7;
            }
        }

        Console.Write("Mode (auto/manual). Press Enter for manual: ");
        string mode = Console.ReadLine();
        bool autoHide = !string.IsNullOrWhiteSpace(mode) && mode.Trim().ToLower().StartsWith("a");

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            if (scripture.IsCompletelyHidden())
            {
                break;
            }

            if (!autoHide)
            {
                Console.Write("Press Enter to hide words, type auto to switch, or type quit: ");
                string input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    string trimmed = input.Trim();
                    if (trimmed.Equals("quit", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }

                    if (trimmed.Equals("auto", StringComparison.OrdinalIgnoreCase))
                    {
                        autoHide = true;
                        continue;
                    }
                }
            }
            else
            {
                Console.WriteLine("Auto mode: hiding every 2 seconds (press Q to quit).");
                int waitedMs = 0;
                while (waitedMs < 2000)
                {
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo key = Console.ReadKey(true);
                        if (key.Key == ConsoleKey.Q)
                        {
                            return;
                        }
                    }

                    Thread.Sleep(100);
                    waitedMs += 100;
                }
            }

            int remaining = scripture.GetUnhiddenCount();
            int toHide = Math.Min(rng.Next(minHide, maxHide + 1), remaining);
            if (toHide > 0)
            {
                scripture.HideRandomWords(toHide, rng, true);
            }
        }
    }

    private static List<Scripture> BuildLibrary()
    {
        List<Scripture> library = new List<Scripture>();

        library.Add(new Scripture(
            new Reference("John", 3, 16),
            "For God so loved the world, that he gave his only begotten Son, " +
            "that whosoever believeth in him should not perish, but have everlasting life."
        ));

        library.Add(new Scripture(
            new Reference("Proverbs", 3, 5, 6),
            "Trust in the Lord with all thine heart; and lean not unto thine own understanding. " +
            "In all thy ways acknowledge him, and he shall direct thy paths."
        ));

        library.Add(new Scripture(
            new Reference("2 Nephi", 2, 25),
            "Adam fell that men might be; and men are, that they might have joy."
        ));

        return library;
    }

    private static List<Scripture> LoadLibraryFromFile(string fileName)
    {
        List<Scripture> library = new List<Scripture>();

        if (!File.Exists(fileName))
        {
            return library;
        }

        string[] lines = File.ReadAllLines(fileName);
        foreach (string rawLine in lines)
        {
            string line = rawLine.Trim();
            if (line.Length == 0 || line.StartsWith("#"))
            {
                continue;
            }

            // Expected format:
            // Book|Chapter|StartVerse|EndVerse(optional)|Text
            string[] parts = line.Split('|');
            if (parts.Length < 4)
            {
                continue;
            }

            string book = parts[0].Trim();
            if (!int.TryParse(parts[1], out int chapter))
            {
                continue;
            }

            if (!int.TryParse(parts[2], out int startVerse))
            {
                continue;
            }

            int endVerse = startVerse;
            int textIndex = 3;
            if (parts.Length >= 5 && int.TryParse(parts[3], out int parsedEnd))
            {
                endVerse = parsedEnd;
                textIndex = 4;
            }

            if (textIndex >= parts.Length)
            {
                continue;
            }

            string text = parts[textIndex].Trim();
            if (text.Length == 0)
            {
                continue;
            }

            Reference reference = startVerse == endVerse
                ? new Reference(book, chapter, startVerse)
                : new Reference(book, chapter, startVerse, endVerse);

            library.Add(new Scripture(reference, text));
        }

        return library;
    }
}
