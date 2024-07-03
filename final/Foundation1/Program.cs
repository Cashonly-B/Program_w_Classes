using System;
using System.Reflection;

public class Comment
{
   public string _user;
   public string _commentText;

   public Comment(string user, string text)
   {
    _user = user;
    _commentText = text;
   }
}

public class Video
{
    public string _title;
    public string _youtuber;
    public float _length; //Seconds
    private List<Comment> _comments;

    public Video(string title, string youtuber, float length)
    {
        _title = title;
        _youtuber = youtuber;
        _length = length;
        _comments = new List<Comment>();
    }
    public void AddComment(Comment comment) { _comments.Add(comment); }
    public int NumberOfComments() { return _comments.Count(); }
    public List<Comment> GetComments() { return _comments; }


    public class Program
    {
        public static void Main()
        {
            // Videos
            Video video1 = new Video("Minecraft Let's Play (Part 1)", "Cashonly", 930);
            Video video2 = new Video("My First Song!", "KatVal", 216);
            Video video3 = new Video("Everything you need to know about cmd prompt commands", "TechyGuy", 645);

            // Comments
            video1.AddComment(new Comment("The Man Ethan", "Yoooo, great video my guy! LOVED IT!!!"));
            video1.AddComment(new Comment("Schwoz", "This video is absolute fire."));
            video1.AddComment(new Comment("Ron2004", "Awesome job. You earned a sub!"));

            video2.AddComment(new Comment("Victory Girl17", "OH MY GOSH WHAT AN AWESOME SONG!! Great job girl!"));
            video2.AddComment(new Comment("Cashonly", "Wow, this song fanstanic! Nice job!"));
            video2.AddComment(new Comment("Andrew Harris", "Didn't know you had such a great voice! Awesome!"));
            video2.AddComment(new Comment("Rolling Robbie244", "That's going on my playlist."));

            video3.AddComment(new Comment("McMuffin52", "Useful info. Thank you."));
            video3.AddComment(new Comment("Oinkster Man", "Thank you for the helpful tips."));
            video3.AddComment(new Comment("Billy Hardman", "Good vid."));

            // Add videos to list
            List<Video> videos = new List<Video> { video1, video2, video3 };

            // Print
            foreach (var video in videos)
            {
                Console.WriteLine($"Video Title: {video._title}");
                Console.WriteLine($"Author: {video._youtuber}");
                Console.WriteLine($"Length: {video._length} seconds ({video._length / 60} minutes)");
                Console.WriteLine($"Number of Comments: {video.NumberOfComments()}");

                foreach (var comment in video.GetComments())
                {
                    Console.WriteLine($"{comment._user}: {comment._commentText}");
                }
                Console.WriteLine("\n");
            }

        }
    }
}