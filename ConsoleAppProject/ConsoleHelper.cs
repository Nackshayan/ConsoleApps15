using System;

namespace ConsoleAppProject
{
    /// <summary>
    /// This is a general purpose class containing methods
    /// that can be used by other console based classes.
    /// Methods to input numbers from the user, and ask the
    /// user to select a choice from a list of choices.
    /// There are methods for outputting a main heading
    /// and a title.
    /// </summary>
    /// <author>
    /// Modified by Nackshayan 1.2
    /// </author>
    public static class ConsoleHelper
    {
        /// <summary>
        /// Prints a heading for each App with its title and author
        /// in green text.
        /// </summary>
        /// <param name="heading">The title of the application.</param>
        public static void OutputHeading(string heading)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("\n\t-------------------------------------");
            Console.WriteLine($"\t  {heading}");
            Console.WriteLine("\t\t  By Nackshayan");
            Console.WriteLine("\t-------------------------------------\n");

            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        /// <summary>
        /// Outputs a title in green text with a dashed underline.
        /// </summary>
        /// <param name="title">The title to be outputted.</param>
        public static void OutputTitle(string title)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"\n{title}");
            Console.Write(" ");

            for (int count = 0; count <= title.Length; count++)
            {
                Console.Write("-");
            }

            Console.WriteLine("\n");
            Console.ResetColor();
        }

        /// <summary>
        /// Shows the choices to the user as a numbered list.
        /// </summary>
        /// <param name="choices">The list of choices the user can make.</param>
        public static void DisplayChoices(string[] choices)
        {
            int choiceNo = 0;

            foreach (string choice in choices)
            {
                choiceNo++; // Incremented at the start so it begins at 1.
                Console.WriteLine($"\t{choiceNo}. {choice}");
            }
        }

        /// <summary>
        /// Gives the user a prompt to input a valid number. After a valid input,
        /// it's returned.
        /// </summary>
        /// <param name="prompt">Prompts the user to input a valid number.</param>
        /// <returns>The user's input number if valid.</returns>
        public static double InputNumber(string prompt)
        {
            double number = 0;
            bool isValid;

            do
            {
                Console.Write(prompt);
                string value = Console.ReadLine();

                try
                {
                    number = Convert.ToDouble(value);
                    isValid = true;
                }
                catch (Exception)
                {
                    isValid = false;
                    Console.WriteLine("\tInvalid number.\n");
                }
            } while (!isValid);

            return number;
        }

        /// <summary>
        /// Gives the user a prompt to enter a valid number, repeatedly doing
        /// so until they do. Their value will only be returned if it's 
        /// between the mix and max range. 
        /// </summary>
        /// <param name="prompt">Prompts the user to input a valid number.</param>
        /// <param name="min">The minimum accepted threshold for the input.</param>
        /// <param name="max">The maximum accepted threshold for the input.</param>
        /// <returns></returns>
        public static double InputNumber(string prompt, double min, double max)
        {
            bool isValid;
            double number;

            do
            {
                number = InputNumber(prompt);

                if (number < min || number > max)
                {
                    isValid = false;
                    Console.WriteLine($"\tThe number must be in the range " +
                        $"{min}-{max}");
                }
                else
                {
                    isValid = true;
                }
            } while (!isValid);

            return number;
        }

        /// <summary>
        /// Shows the user a numbered list of choices, prompting them
        /// to choose one and this will be returned.
        /// </summary>
        /// <param name="choices">The list of choices the user can make.</param>
        /// <returns>The choice number selected by the user.</returns>
        public static int SelectChoice(string[] choices)
        {
            int choiceNo;
            int lastChoice = choices.Length;
            bool isValid;

            string errorMsg = $"\n\tInvalid choice, it must be between 1 to {lastChoice}.";

            do
            {
                DisplayChoices(choices);

                choiceNo = (int)InputNumber("\tPlease input choice > ", 1, lastChoice);

                if ((choiceNo < 1) || (choiceNo > lastChoice))
                {
                    isValid = false;
                    Console.WriteLine(errorMsg);
                }
                else
                {
                    isValid = true;
                }
            } while (!isValid);

            return choiceNo;
        }
    }
}
