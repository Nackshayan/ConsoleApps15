using ConsoleAppProject.Helpers;
using System;

namespace ConsoleAppProject.App01
{
    /// <summary>
    /// This App will prompt the user to input a distance
    /// measured in one unit (fromUnit) and it will calculate and
    /// output the equivalent distance in another unit (toUnit)
    /// </summary>
    /// <author>
    /// Nackshayan V2.0
    /// </author>
    public class DistanceConverter
    {
        public const int INCHES_IN_FEET = 12;
        public const int INCHES_IN_MILES = 63360;
        public const int CENTIMETRES_IN_METRES = 100;
        public const int CENTIMETRES_IN_KILOMETRES = 100000;
        public const int CENTIMETRES_IN_MILES = 160934;
        public const int FEET_IN_MILES = 5280;
        public const int METRES_IN_KILOMETRES = 1000;
        public const double INCHES_IN_CENTIMETRES = 0.393701;
        public const double INCHES_IN_METRES = 39.3701;
        public const double INCHES_IN_KILOMETRES = 39370.1;
        public const double CENTIMETRES_IN_FEET = 30.48;
        public const double FEET_IN_METRES = 3.28084;
        public const double FEET_IN_KILOMETRES = 3280.84;
        public const double METRES_IN_MILES = 1609.34;
        public const double MILES_IN_KILOMETRES = 0.621371;

        public const string CENTIMETRES = "Centimetres";
        public const string INCHES = "Inches";
        public const string FEET = "Feet";
        public const string METRES = "Metres";
        public const string KILOMETRES = "Kilometres";
        public const string MILES = "Miles";

        public double FromDistance { get; set; }
        public double ToDistance { get; set; }

        public DistanceUnits FromUnit { get; set; }
        public DistanceUnits ToUnit { get; set; }

        /// <summary>
        /// Output a heading
        /// Prompt user as  to what units they want to convert between 
        /// Ask for input for the distance in the initial unit
        /// Calculate and output the same distance in the second unit
        /// </summary>
        public void Run()
        {
            ConsoleHelper.OutputHeading("App01 - Distance Converter");

            FromUnit = SelectUnit(" Please Select a Unit to Convert From");
            Console.WriteLine($" You have chosen {FromUnit}");

            Console.WriteLine();
            ToUnit = SelectUnit(" Please Select a Unit to Convert To");
            Console.WriteLine($" You have chosen {ToUnit}");

            Console.WriteLine();
            Console.WriteLine($" Converting {FromUnit} to {ToUnit}");
            Console.WriteLine();

            FromDistance = ConsoleHelper.InputNumber($" Please enter the Distance in {FromUnit} > ");

            CalculateDistance();

            OutputDistance();
        }

        /// <summary>
        /// Prints a list of choices for the user to select from
        /// </summary>
        private DistanceUnits SelectUnit(string prompt)
        {
            string[] choices =
            {
                $" {DistanceUnits.Inches}",
                $" {DistanceUnits.Centimetres}",
                $" {DistanceUnits.Feet}",
                $" {DistanceUnits.Metres}",
                $" {DistanceUnits.Kilometres}",
                $" {DistanceUnits.Miles}"
            };

            Console.WriteLine(prompt);
            Console.WriteLine();
            int choice = ConsoleHelper.SelectChoice(choices);

            return ExecuteChoice(choice);
        }

        /// <summary>
        /// Executes the choice of unit based on the number inputted by the user
        /// </summary>
        private static DistanceUnits ExecuteChoice(int choice)
        {
            switch (choice)
            {
                case 1: return DistanceUnits.Inches;
                case 2: return DistanceUnits.Centimetres;
                case 3: return DistanceUnits.Feet;
                case 4: return DistanceUnits.Metres;
                case 5: return DistanceUnits.Kilometres;
                case 6: return DistanceUnits.Miles;

                default: return DistanceUnits.NoUnit;
            }
        }

        /// <summary>
        /// Calculates distance using pre-set constant values based on chosen units
        /// </summary>
        public void CalculateDistance()
        {
            if (FromUnit == DistanceUnits.Inches &&
                ToUnit == DistanceUnits.Centimetres)
            {
                ToDistance = FromDistance / INCHES_IN_CENTIMETRES;
            }
            else if (FromUnit == DistanceUnits.Centimetres &&
                    ToUnit == DistanceUnits.Inches)
            {
                ToDistance = FromDistance * INCHES_IN_CENTIMETRES;
            }
            else if (FromUnit == DistanceUnits.Inches &&
                    ToUnit == DistanceUnits.Feet)
            {
                ToDistance = FromDistance / INCHES_IN_FEET;
            }
            else if (FromUnit == DistanceUnits.Feet &&
                    ToUnit == DistanceUnits.Inches)
            {
                ToDistance = FromDistance * INCHES_IN_FEET;
            }
            else if (FromUnit == DistanceUnits.Inches &&
                    ToUnit == DistanceUnits.Metres)
            {
                ToDistance = FromDistance / INCHES_IN_METRES;
            }
            else if (FromUnit == DistanceUnits.Metres &&
                    ToUnit == DistanceUnits.Inches)
            {
                ToDistance = FromDistance * INCHES_IN_METRES;
            }
            else if (FromUnit == DistanceUnits.Inches &&
                    ToUnit == DistanceUnits.Kilometres)
            {
                ToDistance = FromDistance / INCHES_IN_KILOMETRES;
            }
            else if (FromUnit == DistanceUnits.Kilometres &&
                    ToUnit == DistanceUnits.Inches)
            {
                ToDistance = FromDistance * INCHES_IN_KILOMETRES;
            }
            else if (FromUnit == DistanceUnits.Inches &&
                    ToUnit == DistanceUnits.Miles)
            {
                ToDistance = FromDistance / INCHES_IN_MILES;
            }
            else if (FromUnit == DistanceUnits.Miles &&
                    ToUnit == DistanceUnits.Inches)
            {
                ToDistance = FromDistance * INCHES_IN_MILES;
            }
            else if (FromUnit == DistanceUnits.Centimetres &&
                    ToUnit == DistanceUnits.Feet)
            {
                ToDistance = FromDistance / CENTIMETRES_IN_FEET;
            }
            else if (FromUnit == DistanceUnits.Feet &&
                    ToUnit == DistanceUnits.Centimetres)
            {
                ToDistance = FromDistance * CENTIMETRES_IN_FEET;
            }
            else if (FromUnit == DistanceUnits.Centimetres &&
                    ToUnit == DistanceUnits.Metres)
            {
                ToDistance = FromDistance / CENTIMETRES_IN_METRES;
            }
            else if (FromUnit == DistanceUnits.Metres &&
                    ToUnit == DistanceUnits.Centimetres)
            {
                ToDistance = FromDistance * CENTIMETRES_IN_METRES;
            }
            else if (FromUnit == DistanceUnits.Centimetres &&
                    ToUnit == DistanceUnits.Kilometres)
            {
                ToDistance = FromDistance / CENTIMETRES_IN_KILOMETRES;
            }
            else if (FromUnit == DistanceUnits.Kilometres &&
                    ToUnit == DistanceUnits.Centimetres)
            {
                ToDistance = FromDistance * CENTIMETRES_IN_KILOMETRES;
            }
            else if (FromUnit == DistanceUnits.Centimetres && 
                ToUnit == DistanceUnits.Miles)
            {
                ToDistance = FromDistance / CENTIMETRES_IN_MILES;
            }
            else if (FromUnit == DistanceUnits.Miles &&
                    ToUnit == DistanceUnits.Centimetres)
            {
                ToDistance = FromDistance * CENTIMETRES_IN_MILES;
            }
            else if (FromUnit == DistanceUnits.Feet &&
                    ToUnit == DistanceUnits.Metres)
            {
                ToDistance = FromDistance / FEET_IN_METRES;
            }
            else if (FromUnit == DistanceUnits.Metres &&
                    ToUnit == DistanceUnits.Feet)
            {
                ToDistance = FromDistance * FEET_IN_METRES;
            }
            else if (FromUnit == DistanceUnits.Feet &&
                    ToUnit == DistanceUnits.Miles)
            {
                ToDistance = FromDistance / FEET_IN_MILES;
            }
            else if (FromUnit == DistanceUnits.Miles &&
                    ToUnit == DistanceUnits.Feet)
            {
                ToDistance = FromDistance * FEET_IN_MILES;
            }
            else if (FromUnit == DistanceUnits.Feet &&
                    ToUnit == DistanceUnits.Kilometres)
            {
                ToDistance = FromDistance / FEET_IN_KILOMETRES;
            }
            else if (FromUnit == DistanceUnits.Kilometres &&
                    ToUnit == DistanceUnits.Feet)
            {
                ToDistance = FromDistance * FEET_IN_KILOMETRES;
            }
            else if (FromUnit == DistanceUnits.Metres &&
                    ToUnit == DistanceUnits.Kilometres)
            {
                ToDistance = FromDistance / METRES_IN_KILOMETRES;
            }
            else if (FromUnit == DistanceUnits.Kilometres &&
                    ToUnit == DistanceUnits.Metres)
            {
                ToDistance = FromDistance * METRES_IN_KILOMETRES;
            }
            else if (FromUnit == DistanceUnits.Metres &&
                    ToUnit == DistanceUnits.Miles)
            {
                ToDistance = FromDistance / METRES_IN_MILES;
            }
            else if (FromUnit == DistanceUnits.Miles &&
                    ToUnit == DistanceUnits.Metres)
            {
                ToDistance = FromDistance * METRES_IN_MILES;
            }
            else if (FromUnit == DistanceUnits.Miles &&
                    ToUnit == DistanceUnits.Kilometres)
            {
                ToDistance = FromDistance / MILES_IN_KILOMETRES;
            }
            else if (FromUnit == DistanceUnits.Kilometres &&
                    ToUnit == DistanceUnits.Miles)
            {
                ToDistance = FromDistance * MILES_IN_KILOMETRES;
            }
        }

        /// <summary>
        /// Print out the result of the conversion from miles to metres
        /// </summary>
        private void OutputDistance()
        {
            Console.WriteLine();
            Console.WriteLine($" {FromDistance} {FromUnit} " +
                $"is {ToDistance} {ToUnit}");
        }
    }
}