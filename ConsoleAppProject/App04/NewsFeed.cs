using ConsoleAppProject.Helpers;
using System;
using System.Collections.Generic;

namespace ConsoleAppProject.App04
{
    /// <summary>
    /// The NewsFeed class stores news posts for the news feed 
    /// in a social network application
    /// </summary>
    /// <author>
    ///  Nackshayan v2.5
    /// </author> 
    public class NewsFeed
    {
        private readonly List<Post> posts;

        ///<summary>
        /// Construct a news feed containing sample posts
        ///</summary>
        public NewsFeed()
        {
            posts = new List<Post>();

            MessagePost messagePost = new MessagePost(" Nackshayan",
                " Welcome to avengers");
            AddMessagePost(messagePost);

            PhotoPost photoPost = new PhotoPost(" Nackshayan",
                "Aven1.jpg", "Welcome to avengers");
            AddPhotoPost(photoPost);
        }

        ///<summary>
        /// Add a text post to the news feed
        ///</summary>
        public void AddMessagePost(MessagePost message)
        {
            posts.Add(message);
        }

        ///<summary>
        /// Add a photo post to the news feed
        ///</summary>
        public void AddPhotoPost(PhotoPost photo)
        {
            posts.Add(photo);
        }

        /// <summary>
        /// Find a post according to the ID assigned to each 
        /// post
        /// </summary>
        public Post FindPostByID(int id)
        {
            foreach (Post post in posts)
            {
                if (post.postID == id)
                {
                    return post;
                }
            }

            return null;
        }

        /// <summary>
        /// Find a post according to the ID assigned to each 
        /// post
        /// </summary>
        public Post FindPostByAuthor(string author)
        {
            foreach (Post post in posts)
            {
                if (post.Author == author)
                {
                    return post;
                }
            }

            return null;
        }

        /// <summary>
        /// Find a post according to the ID assigned to each 
        /// post
        /// </summary>
        public Post FindPostByDate(DateTime date)
        {
            foreach (Post post in posts)
            {
                if (post.Timestamp == date)
                {
                    return post;
                }
            }

            return null;
        }

        /// <summary>
        /// Find a post using a given ID and remove the selected post
        /// from the News Feed
        /// </summary>
        public void RemovePost(int id)
        {
            ConsoleHelper.OutputTitle(" Removing a Post");
            Post post = FindPostByID(id);

            if (post == null)
            {
                Console.WriteLine();
                Console.WriteLine($" Post with ID {id} does not exist");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($" The Post with ID {id} has been removed");

                posts.Remove(post);
                post.Display();
            }
        }

        ///<summary>
        /// Shows the news feed details to the terminal
        ///</summary>
        public void Display()
        {
            ConsoleHelper.OutputTitle(" Displaying All Posts");
            Console.WriteLine();

            foreach (Post post in posts)
            {
                post.Display();
                Console.WriteLine();
            }
        }

        ///<summary>
        /// Shows the news feed details to the terminal
        ///</summary>
        public void DisplayByAuthor(string author)
        {
            ConsoleHelper.OutputTitle(" Displaying Posts by Author");

            foreach (Post post in posts)
            {
                if (author == null)
                {
                    Console.WriteLine();
                    Console.WriteLine($" There are no Posts by {author}");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine($" All Posts by {author}");

                    post.Display();

                    Console.WriteLine();
                }
            }
        }

        public void DisplayByDate(DateTime date)
        {
            ConsoleHelper.OutputTitle(" Displaying Posts by Author");

            foreach (Post post in posts)
            {
                if (date == null)
                {
                    Console.WriteLine();
                    Console.WriteLine($" There are no Posts on {date}");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine($" All Posts on {date}");

                    post.Display();

                    Console.WriteLine();
                }
            }
        }

        public void Comment(int id)
        {
            ConsoleHelper.OutputTitle(" Commenting on a Post");
            Post post = FindPostByID(id);

            if (post == null)
            {
                Console.WriteLine();
                Console.WriteLine($" Post with ID {id} does not exist");
            }
            else
            {
                Console.WriteLine();
                Console.Write($" Please enter your Comment > ");
                string text = Console.ReadLine();

                post.AddComment(text);

                Console.WriteLine();

                post.Display();
            }
        }

        public void LikePost(int id)
        {
            Post post = FindPostByID(id);

            if (post == null)
            {
                Console.WriteLine();
                Console.WriteLine($" Post with ID {id} does not exist");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($" You have Liked post with ID {id}");

                post.Like();

                Console.WriteLine();

                post.Display();
            }
        }

        public void UnlikePost(int id)
        {
            Post post = FindPostByID(id);

            if (post == null)
            {
                Console.WriteLine();
                Console.WriteLine($" Post with ID {id} does not exist");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($" You have Unliked post with ID {id}");

                post.Unlike();

                Console.WriteLine();

                post.Display();
            }
        }
    }
}