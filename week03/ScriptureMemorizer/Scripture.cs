using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] parts = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (string part in parts)
        {
            _words.Add(new Word(part));
        }
    }

    public string GetDisplayText()
    {
        List<string> display = new List<string>();
        foreach (Word word in _words)
        {
            display.Add(word.GetDisplayText());
        }

        return $"{_reference.GetDisplayText()} {string.Join(" ", display)}";
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }

        return true;
    }

    public int GetUnhiddenCount()
    {
        int count = 0;
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                count++;
            }
        }

        return count;
    }

    public void HideRandomWords(int count, Random rng, bool onlyUnhidden)
    {
        if (count <= 0 || _words.Count == 0)
        {
            return;
        }

        int attempts = 0;
        int hidden = 0;

        while (hidden < count && attempts < _words.Count * 4)
        {
            int index = rng.Next(_words.Count);
            Word word = _words[index];

            if (!onlyUnhidden || !word.IsHidden())
            {
                if (!word.IsHidden())
                {
                    word.Hide();
                    hidden++;
                }
            }

            attempts++;
        }
    }
}
