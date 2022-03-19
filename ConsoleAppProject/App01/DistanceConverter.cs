using System;

namespace ConsoleAppProject.App01
{
    /// <summary>
    /// This App converts a user-inputted distance in either miles, feet or metres,
    /// converting it into its equivalent distance in another unit 
    /// (both units being selected by the user at the start) 
    /// and displaying the result to the user afterwards.
    /// </summary>
    /// <author>
    /// Nackshayan v 1.2 
    /// </author>
    public class DistanceConverter
    {
        // Constants for distance conversion
        public const int FEET_IN_MILES = 5280;
        public const double FEET_IN_METRES = 3.28084;
        public const double METRES_IN_MILES = 1609.34;

        // Properties for distance values and units.
        public double FromDistance { get; set; }
        public double ToDistance { get; set; }
        public DistanceUnits FromUnit { get; set; }
        public DistanceUnits ToUnit { get; set; }

        /// <summary>
        /// Constructor for the DistanceConverter class.
        /// </summary>
        public DistanceConverter()
        {
            FromUnit = DistanceUnits.Miles;
            ToUnit = DistanceUnits.Feet;
        }

        /// <summary>
        /// Asks the user to input a distance, which is then converted into the unit 
        /// they selected at the start, and the result is 
        /// displayed on-screen.
        /// </summary>
        public void ConvertDistance()
        {
            ConsoleHelper.OutputHeading("Distance Conversion Calculator");

            FromUnit = SelectUnit("From Unit");
            ToUnit = SelectUnit("To Unit");

            /// If the user has selected the From and To units with the same
            /// choice, an error message will appear and will keep doing so
            /// until they choose a different To unit.
            while (ToUnit == FromUnit)
            {
                Console.WriteLine("\tThe To unit cannot be the same as " +
                    "the From unit. Please try again.\n");
                ToUnit = SelectUnit("To Unit");
            }

            Console.WriteLine($"\t{FromUnit} -> {ToUnit} Conversion");

            FromDistance = ConsoleHelper.InputNumber($"\tPlease enter the number of {FromUnit} > ");

            CalculateDistance();

            OutputDistance();

            ExitDecision();
        }

        /// <summary>
        /// Asks the user to select their choices (source and destination distance units for conversion)
        /// and then executes the conversion.
        /// </summary>
        /// <param name="prompt">The user's selected choice.</param>
        /// <returns>The execution of the user's choice.</returns>
        public DistanceUnits SelectUnit(string prompt)
        {
            int choice = ShowChoices(prompt);

            DistanceUnits unit = ExecuteChoice(choice);
            Console.WriteLine($"\t{unit} has been selected.\n");

            return unit;
        }

        /// <summary>
        /// Shows the unit choices to the user.
        /// </summary>
        /// <param name="prompt">Prompts the user to enter a choice for the distance unit.</param>
        /// <returns>The user's selected choice.</returns>
        private int ShowChoices(string prompt)
        {
            Console.WriteLine("\t" + prompt);

            string[] choices = { $"\t{DistanceUnits.Miles}",
                                 $"\t{DistanceUnits.Feet}",
                                 $"\t{DistanceUnits.Metres}"};

            int choice = ConsoleHelper.SelectChoice(choices);
            return choice;
        }

        /// <summary>
        /// Executes the conversion based on the user's choices.
        /// </summary>
        /// <param name="choice">The choice made by the user.</param>
        /// <returns>The unit representing the user's choice.</returns>
        private DistanceUnits ExecuteChoice(int choice)
        {
            DistanceUnits unit;

            switch (choice)
            {
                case 1:
                    unit = DistanceUnits.Miles;
                    break;
                case 2:
                    unit = DistanceUnits.Feet;
                    break;
                case 3:
                    unit = DistanceUnits.Metres;
                    break;
                default:
                    unit = DistanceUnits.NoUnit;
                    break;
            }
        
            if (unit == DistanceUnits.NoUnit)
            {
                Console.WriteLine("Invalid choice. Your choice must be in" +
                    " the range 1-3.");
            }

            return unit;
        }

        /// <summary>
        /// Outputs the converted distance to the user to 2 decimal places.
        /// </summary>
        private void OutputDistance()
        {
            Console.WriteLine($"\t{FromDistance} {FromUnit} = {ToDistance:0.00} {ToUnit}");
        }

        /// <summary>
        /// Calculates the distance conversion depending on the units selected
        /// by the user at the start.
        /// </summary>
        public void CalculateDistance()
        {
            if (FromUnit == DistanceUnits.Miles && ToUnit == DistanceUnits.Feet)
            {
                ToDistance = FromDistance * FEET_IN_MILES;
            }
            else if (FromUnit == DistanceUnits.Feet && ToUnit == DistanceUnits.Miles)
            {
                ToDistance = FromDistance / FEET_IN_MILES;
            }
            else if (FromUnit == DistanceUnits.Miles && ToUnit == DistanceUnits.Metres)
            {
                ToDistance = FromDistance * METRES_IN_MILES;
            }
            else if (FromUnit == DistanceUnits.Metres && ToUnit == DistanceUnits.Miles)
            {
                ToDistance = FromDistance / METRES_IN_MILES;
            }
            else if (FromUnit == DistanceUnits.Metres && ToUnit == DistanceUnits.Feet)
            {
                ToDistance = FromDistance * FEET_IN_METRES;
            }
            else if (FromUnit == DistanceUnits.Feet && ToUnit == DistanceUnits.Metres)
            {
                ToDistance = FromDistance / FEET_IN_METRES;
            }
        }

        /// <summary>
        /// Gives the user the option to either exit the application after getting a conversion result or return
        /// to the menu to convert another distance.
        /// </summary>
        private void ExitDecision()
        {
            Console.Write("\n\tWould you like to exit? Selecting 'n' will return you to the menu (y/n) > ");

            string choice = Console.ReadLine();

            if (choice == "y")
            {
                Console.WriteLine("\tThank you for using this calculator. Goodbye for now!");
                Environment.Exit(0);
            }
            else if (choice == "n")
            {
                ConvertDistance();
            }
            else
            {
                Console.WriteLine("\tInvalid input. Please try again.");
                ExitDecision();
            }
        }
    }
}
