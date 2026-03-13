using System;

public class Entry
{
    private string _date;
    private string _prompt;
    private string _response;
    private string _mood;
    private string _tags;

    public Entry(string date, string prompt, string response, string mood, string tags)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
        _mood = mood;
        _tags = tags;
    }

    public Entry(string date, string prompt, string response)
        : this(date, prompt, response, "N/A", "")
    {
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_prompt}");
        Console.WriteLine($"Mood: {_mood}");
        if (!string.IsNullOrWhiteSpace(_tags))
        {
            Console.WriteLine($"Tags: {_tags}");
        }
        Console.WriteLine(_response);
        Console.WriteLine();
    }

    public string ToStorageString(string separator)
    {
        return $"{_date}{separator}{_prompt}{separator}{_response}{separator}{_mood}{separator}{_tags}";
    }
}
