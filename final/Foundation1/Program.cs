using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video("Introduction to C#", "John Doe", 300);
        Video video2 = new Video("Advanced C# Techniques", "Jane Doe", 600);
        Video video3 = new Video("C# Design Patterns", "Josh Doe", 900);

        // Add comments to videos
        video1.AddComment(new Comment("User1", "Great video!"));
        video1.AddComment(new Comment("User2", "Very helpful, thanks!"));
        video1.AddComment(new Comment("User3", "I learned a lot."));

        video2.AddComment(new Comment("User4", "Excellent content."));
        video2.AddComment(new Comment("User5", "Well explained."));
        video2.AddComment(new Comment("User6", "Thanks for sharing."));

        video3.AddComment(new Comment("User7", "Very informative."));
        video3.AddComment(new Comment("User8", "Loved the examples."));
        video3.AddComment(new Comment("User9", "Great job!"));

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display video information
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}
