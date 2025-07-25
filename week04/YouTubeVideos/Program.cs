using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // A list that hold all video objects
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Exploring 1 Nephi: Lehi's Vision of the tree of life & Nephi's courage to get the brass plates from laban", "Book of Mormon Stories", 25 * 60); 
        video1.AddComment(new Comment("Sarah", "Loved the breakdown of lehi's vision of the tree of life! So much symbolism."));
        video1.AddComment(new Comment("Mark", "Nephi's courage in getting the plates is truly inspiring."));
        video1.AddComment(new Comment("Jessica", "How do we apply Nephi's 'I will go and do' principle in modern life?"));
        videos.Add(video1);

        Video video2 = new Video("Alma 32: The Zoramites and Experimenting on the Word", "Daily Scriptures", 35 * 60); 
        video2.AddComment(new Comment("David", "Alma's teachings on faith are so profound. This video made it click!"));
        video2.AddComment(new Comment("Emily", "The humility of the Zoramites, even forced, led to a beautiful sermon."));
        video2.AddComment(new Comment("Chris", "Great explanation of how we can 'nourish' the word like a seed."));
        video2.AddComment(new Comment("Laura", "This is exactly what I needed for my Sunday School lesson preparation."));
        videos.Add(video2);

        Video video3 = new Video("The Jaredites: Lessons from the Book of Ether", "Ancient America findings", 20 * 60); 
        video3.AddComment(new Comment("Michael", "The account of the Jaredites' journey is incredible. Never thought about their barges like this!"));
        video3.AddComment(new Comment("Olivia", "The Brother of Jared's faith to see the Lord's finger gives me chills."));
        video3.AddComment(new Comment("Daniel", "What can we learn from the fall of mighty civilizations like the Jaredites?"));
        videos.Add(video3);

        Video video4 = new Video("Moroni's Promise and the Power of the Holy Ghost", "Covenant Path Conversations", 18 * 60); 
        video4.AddComment(new Comment("Sophia", "Moroni 10:4-5 changed my life. Thank you for this insightful video!"));
        video4.AddComment(new Comment("James", "This helps so much with explaining spiritual witnesses to others."));
        video4.AddComment(new Comment("Chloe", "The Holy Ghost truly confirms truth. I felt it watching this."));
        videos.Add(video4);


        Console.WriteLine("--- Book of Mormon Video & Comment Analysis ---");
        Console.WriteLine("-----------------------------------------------\n");

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: \"{video.GetTitle()}\"");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLengthInSeconds()} seconds ({video.GetLengthInSeconds() / 60} minutes)"); 
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.GetCommenterName()}: \"{comment.GetCommentText()}\"");
            }
            Console.WriteLine("\n-----------------------------------------------\n"); // Separator for readability
        }
    }
}