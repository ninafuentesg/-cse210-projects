using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
      
        Video video1 = new Video("Learn C# in 20 Minutes", "Programming Hub", 1200);
        Video video2 = new Video("Top 10 Places in Japan", "Travel World", 850);
        Video video3 = new Video("Easy Chocolate Cake Recipe", "Cooking Time", 600);
        Video video4 = new Video("The Solar System Explained", "Science Daily", 980);

   
        video1.AddComment(new Comment("Alice", "Excellent explanation!"));
        video1.AddComment(new Comment("Brian", "Very easy to understand."));
        video1.AddComment(new Comment("Chris", "Thanks for sharing."));
        video1.AddComment(new Comment("Diana", "This helped me a lot."));

        video2.AddComment(new Comment("Emma", "Japan looks amazing!"));
        video2.AddComment(new Comment("Frank", "I want to visit Tokyo."));
        video2.AddComment(new Comment("Grace", "Beautiful places."));
        video2.AddComment(new Comment("Henry", "Great video!"));

       
        video3.AddComment(new Comment("Isabella", "Looks delicious."));
        video3.AddComment(new Comment("Jack", "I'll try this recipe."));
        video3.AddComment(new Comment("Karen", "Thanks for the tips."));
        video3.AddComment(new Comment("Leo", "My family loved it."));

        video4.AddComment(new Comment("Maria", "Very educational."));
        video4.AddComment(new Comment("Nathan", "Awesome animations."));
        video4.AddComment(new Comment("Olivia", "Science is fascinating."));
        video4.AddComment(new Comment("Peter", "I learned a lot today."));

        List<Video> videos = new List<Video>();

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        videos.Add(video4);

       
        foreach (Video video in videos)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Comments: {video.GetNumberOfComments()}");
            Console.WriteLine();

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"{comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}