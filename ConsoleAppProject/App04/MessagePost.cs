using System;

namespace ConsoleAppProject.App04
{
    /// <summary>
    /// This class stores information about a post in a social network. 
    /// The main part of the post consists of a (possibly multi-line)
    /// text message
    /// </summary>
    /// <author>
    /// Nackshayan 21/05/2022
    /// </author>
    public class MessagePost : Post
    {
        public String Message { get; }

        /// <summary>
        /// Constructor for objects of class MessagePost.
        /// </summary>
        public MessagePost(String author, String text):base(author)
        {
            Message = text;
        }

        public override void Display()
        {
            Console.WriteLine($" Message:{Message}");
            base.Display();
        }
    }
}