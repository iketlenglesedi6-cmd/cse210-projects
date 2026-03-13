using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    private const string Separator = "|~|";
    private Random _random = new Random();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("Journal is empty.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void DisplayRandomEntry()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("Journal is empty.");
            return;
        }

        int index = _random.Next(_entries.Count);
        _entries[index].Display();
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.ToStorageString(Separator));
            }
        }
    }


    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        _entries.Clear();

        foreach (string line in lines)
        {
            string[] parts = line.Split(Separator);
            if (parts.Length < 3)
            {
                continue;
            }

            string date = parts[0];
            string prompt = parts[1];
            string response = parts[2];
            string mood = parts.Length >= 4 ? parts[3] : "N/A";
            string tags = parts.Length >= 5 ? parts[4] : "";

            Entry entry = new Entry(date, prompt, response, mood, tags);
            _entries.Add(entry);
        }
    }
}
