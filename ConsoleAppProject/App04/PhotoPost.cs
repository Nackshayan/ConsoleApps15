using System;

namespace ConsoleAppProject.App04
{
    /// <summary>
    /// This class stores information about a post in a social network. 
    /// The main part of the post consists of a photo and a caption
    /// </summary>
    /// <author>
    /// Nackshayan V2.5
    /// </author>
    public class PhotoPost : Post
    {
        public String Filename { get; set; }
        
        public String Caption { get; set; }   

        ///<summary>
        /// Constructor for objects of class PhotoPost.
        ///</summary>
        public PhotoPost(String author, String filename, String caption): base(author)
        {
            this.Filename = filename;
            this.Caption = caption;
        }

        public override void Display()
        {
            Console.WriteLine($" Photo: {Filename}");
            Console.WriteLine($" Caption: {Caption}");
            base.Display();
        }
    }
}