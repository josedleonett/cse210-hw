using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Comment comment1 = new Comment("John", "I love this product, I use it every day!");
        Comment comment2 = new Comment("Anna", "Can you tell me more about how this product works?");
        Comment comment3 = new Comment("Carlos", "This video made me want to buy the product!");
        Comment comment4 = new Comment("Mary", "Great demo of the product, very useful.");
        Comment comment5 = new Comment("Luis", "I’m thinking of buying this after watching the video.");
        Comment comment6 = new Comment("Pedro", "This product looks amazing, I’ll check it out.");
        Comment comment7 = new Comment("Sophia", "I can’t wait to try this out!");
        Comment comment8 = new Comment("Diego", "Very informative and engaging!");
        Comment comment9 = new Comment("Laura", "I learned a lot from this unboxing!");

        Video video1 = new Video("How to Use Product X", "John Doe", 300);
        video1.AddComment(comment1);
        video1.AddComment(comment2);
        video1.AddComment(comment3);

        Video video2 = new Video("Product Y Review", "Jane Smith", 450);
        video2.AddComment(comment4);
        video2.AddComment(comment5);
        video2.AddComment(comment6);
        
        Video video3 = new Video("Unboxing Product Z", "Bob Johnson", 600);
        video3.AddComment(comment7);
        video3.AddComment(comment8);
        video3.AddComment(comment9);

        List<Video> videos = new List<Video>() { video1, video2, video3 };

        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.CommentCount()}");
            Console.WriteLine("Comments:");

            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"  {comment.GetAuthor()}: {comment.GetContent()}");
            }
            
            Console.WriteLine();
        }
    }
}
