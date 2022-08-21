using System;
using System.Collections.Generic;

namespace ConsoleAppProject.App04
{
    /// <summary>
    /// This class stores information about posts in a
    /// social network, including the Post ID, Author name,
    /// Timestamp, Likes and Comments
    /// </summary>
    /// <author>
    /// Nackshayan V2.5
    /// </author>
    [Serializable]
    public class Post
    {
        public int postID { get; }

        public string Author { get; }

        public DateTime Timestamp { get; }

        private static int instances = 0;

        private int likes;

        private readonly List<String> comments;

        /// <summary>
        /// Constructor for objects of class Post
        /// </summary>
        public Post(string author)
        {
            instances++;
            postID = instances;

            this.Author = author;
            Timestamp = DateTime.Now;

            likes = 0;
            comments = new List<String>();
        }

        /// <summary>
        /// Record one more 'Like' indication from a user
        /// </summary>
        public void Like()
        {
            likes++;
        }

        ///<summary>
        /// Record that a user has withdrawn their 'Like' vote
        ///</summary>
        public void Unlike()
        {
            if (likes > 0)
            {
                likes--;
            }
        }

        ///<summary>
        /// Add a comment to this post
        /// </summary>     
        public void AddComment(String text)
        {
            comments.Add(text);
        }

        ///<summary>
        /// Display the details of this post
        ///</summary>
        public virtual void Display()
        {
            Console.WriteLine();
            Console.WriteLine($" Post ID: {postID}");
            Console.WriteLine($" Author: {Author}");
            Console.WriteLine($" Time Elapsed: {FormatElapsedTime(Timestamp)}");
            Console.WriteLine();

            if (likes > 0)
            {
                Console.WriteLine($" Likes: {likes} people like this.");
            }
            else
            {
                Console.WriteLine();
            }

            if (comments.Count == 0)
            {
                Console.WriteLine(" No comments.");
            }
            else
            {
                Console.WriteLine($" {comments.Count} comment(s). Click here to view.");
            }
            Console.WriteLine();
        }

        ///<summary>
        /// Create a string describing a time point in the past relative 
        /// to current time
        /// </summary>     
        private String FormatElapsedTime(DateTime time)
        {
            DateTime current = DateTime.Now;
            TimeSpan timePast = current - time;

            long seconds = (long)timePast.TotalSeconds;
            long minutes = seconds / 60;

            if (minutes > 0)
            {
                return minutes + " minutes ago";
            }
            else
            {
                return seconds + " seconds ago";
            }
        }
    }
}