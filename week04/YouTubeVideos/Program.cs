using System;

namespace YouTubeTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            var video1 = new Video("C# Tutorial for Beginners", "Programming Master", 600);
            var video2 = new Video("Learn OOP in 30 Minutes", "Code Guru", 1800);
            var video3 = new Video("ASP.NET Core Crash Course", "Web Dev Simplified", 2400);
            var video4 = new Video("Design Patterns Explained", "Software Architect", 3600);

            video1.AddComment(
                new Comment("JohnDoe", "Great tutorial! Very helpful for beginners.")
            );
            video1.AddComment(new Comment("JaneSmith", "I finally understand classes, thanks!"));
            video1.AddComment(
                new Comment("MikeJohnson", "Could you make a video on interfaces next?")
            );

            video2.AddComment(new Comment("AliceW", "Perfect explanation of polymorphism."));
            video2.AddComment(new Comment("BobT", "A bit fast paced but good content."));
            video2.AddComment(new Comment("CharlieG", "Would love more examples."));
            video2.AddComment(new Comment("DianaP", "Best OOP video I've seen!"));

            video3.AddComment(new Comment("DevPro", "Exactly what I needed for my project."));
            video3.AddComment(new Comment("NewbieCoder", "Some parts were confusing."));
            video3.AddComment(new Comment("SeniorDev", "Clear and concise. Well done!"));

            video4.AddComment(
                new Comment("PatternLover", "Singleton pattern explained perfectly!")
            );
            video4.AddComment(new Comment("DesignFan", "When will you cover MVC pattern?"));
            video4.AddComment(
                new Comment("ArchitectInTraining", "This helped me ace my interview.")
            );

            List<Video> videos = new List<Video> { video1, video2, video3, video4 };

            DisplayVideoInfo(videos);
        }

        static void DisplayVideoInfo(List<Video> videos)
        {
            foreach (var video in videos)
            {
                Console.WriteLine($"Title: {video._title}");
                Console.WriteLine($"Author: {video._author}");
                Console.WriteLine($"Length: {video._lengthInSeconds} seconds");
                Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

                Console.WriteLine("Comments:");
                foreach (var comment in video.GetAllComments())
                {
                    Console.WriteLine($"- {comment.CommenterName}: {comment.CommentText}");
                }

                Console.WriteLine();
            }
        }
    }
}
