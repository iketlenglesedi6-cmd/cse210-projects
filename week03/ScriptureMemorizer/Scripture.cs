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

        List<int> candidates = new List<int>();
        for (int i = 0; i < _words.Count; i++)
        {
            if (!onlyUnhidden || !_words[i].IsHidden())
            {
                if (!_words[i].IsHidden())
                {
                    candidates.Add(i);
                }
            }
        }

        int toHide = Math.Min(count, candidates.Count);
        for (int i = 0; i < toHide; i++)
        {
            int pick = rng.Next(candidates.Count);
            int index = candidates[pick];
            _words[index].Hide();
            candidates.RemoveAt(pick);
        }
    }
}
