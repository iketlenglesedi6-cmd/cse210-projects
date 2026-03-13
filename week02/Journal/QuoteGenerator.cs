using System;
using System.Collections.Generic;

public class QuoteGenerator
{
    private List<string> _quotes = new List<string>
    {
        "Small steps still move you forward.",
        "You are allowed to pause without quitting.",
        "Progress counts, even if it is quiet.",
        "Be kind to yourself today.",
        "One good moment is still a good day.",
        "You do not have to be perfect to be proud.",
        "Show up for the moment you are in."
    };

    private Random _random = new Random();

    public string GetRandomQuote()
    {
        int index = _random.Next(_quotes.Count);
        return _quotes[index];
    }
}
