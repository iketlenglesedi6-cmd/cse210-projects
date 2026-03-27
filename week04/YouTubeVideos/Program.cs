using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("C# Basics in 10 Minutes", "Code With Sky", 620);
        video1.AddComment(new Comment("Riley", "Clear and quick explanation."));
        video1.AddComment(new Comment("Sam", "The examples helped a lot."));
        video1.AddComment(new Comment("Alex", "Please make a part two!"));

        Video video2 = new Video("Building a Simple Game Loop", "Dev Sandbox", 845);
        video2.AddComment(new Comment("Morgan", "Loved the pacing."));
        video2.AddComment(new Comment("Jamie", "Can you cover input handling next?"));
        video2.AddComment(new Comment("Taylor", "Great intro to game loops."));
        video2.AddComment(new Comment("Jordan", "This finally clicked for me."));

        Video video3 = new Video("Debugging Tips for Beginners", "Bug Hunter", 540);
        video3.AddComment(new Comment("Casey", "Breakpoints are a game changer."));
        video3.AddComment(new Comment("Drew", "Nice checklist, thanks!"));
        video3.AddComment(new Comment("Quinn", "I needed this today."));

        List<Video> videos = new List<Video> { video1, video2, video3 };

        foreach (Video video in videos)
        {
            DisplayVideo(video);
        }
    }

    static void DisplayVideo(Video video)
    {
        Console.WriteLine($"Title: {video.Title}");
        Console.WriteLine($"Author: {video.Author}");
        Console.WriteLine($"Length (seconds): {video.LengthSeconds}");
        Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
        Console.WriteLine("Comments:");

        foreach (Comment comment in video.GetComments())
        {
            Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
        }

        Console.WriteLine();
    }
}
