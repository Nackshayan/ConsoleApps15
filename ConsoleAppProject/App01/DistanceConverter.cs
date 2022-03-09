using System;

namespace ConsoleAppProject.App01
{
    /// <summary>
    /// This App will prompt the user to input a distance
    /// measured in one unit (fromUnit) and will calculate and output
    /// the equivalent distance in another unit (toUnit).
    /// </summary>
    /// <author>
    /// Kate Gordon version 0.6
    /// </author>
    public class DistanceConverter
    {
        // constants
        public const int FEET_IN_MILES = 5280;
        public const double METRES_IN_MILES = 1609.34;
        public const double FEET_IN_METRES = 3.28084;

        public const string FEET = "Feet";
        public const string METRES = "Metres";
        public const string MILES = "Miles";

        // attributes
        private double fromDistance;
        private double toDistance;

        private string fromUnit;
        private string toUnit;

        /// <summary>
        /// Constructor for Distance Converter
        /// </summary>
        public DistanceConverter()
        {
            fromUnit = MILES;
            toUnit = FEET;
        }

        /// <summary>
        /// This method will input the distance measured in miles
        /// calculate the same distance in feet, and output the
        /// distance in feet.
        /// </summary>       
        public void ConvertDistance()
        {
            OutputHeading();

            fromUnit = SelectUnit(" Please select the from distance unit > ");
            toUnit = SelectUnit(" Please select the to distance unit > ");

            Console.WriteLine($"\n Converting {fromUnit} to {toUnit}");

            fromDistance = InputDistance($"\n Please enter the number of {fromUnit} > ");

            CalculateDistance();
            OutputDistance();
        }


        /// <summary>
        /// Method to calculate the convsion based on the user input
        /// distance and selected units
        /// </summary>
        private void CalculateDistance()
        {
            if (fromUnit == MILES && toUnit == FEET)
            {
                toDistance = fromDistance * FEET_IN_MILES;
            }
            else if (fromUnit == FEET && toUnit == MILES)
            {
                toDistance = fromDistance / FEET_IN_MILES;
            }
            else if (fromUnit == MILES && toUnit == METRES)
            {
                toDistance = fromDistance * METRES_IN_MILES;
            }
            else if (fromUnit == METRES && toUnit == MILES)
            {
                toDistance = fromDistance / METRES_IN_MILES;
            }
            else if (fromUnit == METRES && toUnit == FEET)
            {
                toDistance = fromDistance * FEET_IN_METRES;
            }
            else if (fromUnit == FEET && toUnit == METRES)
            {
                toDistance = fromDistance / FEET_IN_METRES;
            }
        }

        /// <summary>
        /// Display a menu of distance units and then
        /// prompt the user to select one and return it.
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        private string SelectUnit(string prompt)
        {
            string choice = DisplayChoices(prompt);

            string unit = ExecuteChoice(choice);
            Console.WriteLine($"\n You have chosen {unit}");
            return unit;
        }

        /// <summary>
        /// Returns the selected unit of distance
        /// </summary>
        /// <param name="choice"></param>
        /// <returns></returns>
        private static string ExecuteChoice(string choice)
        {

            if (choice.Equals("1"))
            {
                return FEET;
            }
            else if (choice.Equals("2"))
            {
                return METRES;
            }
            else if (choice.Equals("3"))
            {
                return MILES;
            }
            else
            {
                Console.WriteLine("\n Invalid Choice!");
                Console.WriteLine("\n Please use digits 1 to 3.");
                return null;
            }
        }

        /// <summary>
        /// This method displays the options to the user
        /// and prompts the user to select an option for
        /// both the from unit and to unit.
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        private static string DisplayChoices(string prompt)
        {
            Console.WriteLine();
            Console.WriteLine($" 1. {FEET}");
            Console.WriteLine($" 2. {METRES}");
            Console.WriteLine($" 3. {MILES}");
            Console.WriteLine();

            Console.WriteLine(prompt);
            string choice = Console.ReadLine();
            return choice;
        }

        /// <summary>
        /// Prompt the user to enter the fromDistance
        /// distance.
        /// Input the miles as a double number
        /// </summary>  
        private double InputDistance(string prompt)
        {
            Console.Write(prompt);
            string value = Console.ReadLine();
            return Convert.ToDouble(value);
        }

        /// <summary>
        /// This method will output the dstance calculated
        /// by the conversion methods
        /// </summary>  
        private void OutputDistance()
        {
            Console.WriteLine($"\n {fromDistance} {fromUnit}" +
                $" is {toDistance} {toUnit}!\n");
        }

        /// <summary>
        /// This method will output a heading for the 
        /// Distance Converter
        /// </summary>
        private void OutputHeading()
        {
            Console.WriteLine("\n ****************************** ");
            Console.WriteLine(" ******************************  ");
            Console.WriteLine("        Distance Converter        ");
            Console.WriteLine("         by Kate Gordon          ");
            Console.WriteLine(" ******************************   ");
            Console.WriteLine(" ****************************** \n");
        }
    }

}
