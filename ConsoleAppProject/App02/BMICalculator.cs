using ConsoleAppProject.Helpers;
using System;

namespace ConsoleAppProject.App02
{
    /// <summary>
    /// This App will prompt the user to input a distance
    /// measured in one unit (fromUnit) and it will calculate and
    /// output the equivalent distance in another unit (toUnit)
    /// </summary>
    /// <author>
    /// Nackshayan V2.0
    /// </author>
    public class BMICalculator
    {
        public const double BMI_UNDERWEIGHT = 18.5;
        public const double BMI_NORMAL = 18.5;
        public const int BMI_OVERWEIGHT = 25;
        public const int BMI_OBESE_I = 30;
        public const int BMI_OBESE_II = 35;
        public const int BMI_OBESE_III = 40;

        public const string UNDERWEIGHT = "Underweight";
        public const string NORMAL = "Normal";
        public const string OVERWEIGHT = "Overweight";
        public const string CLASS_I_OBESE = "Class I Obese";
        public const string CLASS_II_OBESE = "Class II Obese";
        public const string CLASS_III_OBESE = "Class III Obese";

        public double Feet { get; set; }
        public double Inches { get; set; }
        public double Metres { get; set; }
        public double Centimetres { get; set; }
        public double Stones { get; set; }
        public double Pounds { get; set; }
        public double Kilograms { get; set; }

        public UnitChoices UnitChoice { get; set; }

        public string Category { get; set; }

        public double BMI { get; set; }

        /// <summary>
        /// Output a heading
        /// Prompt user as  to what units they want to convert between 
        /// </summary>
        public void Run()
        {
            ConsoleHelper.OutputHeading("App02 - BMI Calculator");

            OutputIntroduction();

            Console.WriteLine();
            UnitChoice = SelectUnit(" Please Choose whether to use Imperial or Metric Units");
            Console.WriteLine($" You have chosen {UnitChoice} Units");
            Console.WriteLine();

            InputMeasurement();

            CalculateBMI();

            OutputBMI();
        }

        /// <summary>
        /// Prompts the user to input their measurments based on their unit choice
        /// </summary>
        private void InputMeasurement()
        {
            if (UnitChoice.Equals(UnitChoices.Imperial))
            {
                Console.WriteLine($" Please enter your Height in {UnitsList.Feet} and " +
                    $"{UnitsList.Inches}");
                Feet = ConsoleHelper.InputNumber($" {UnitsList.Feet} > ");
                Inches = ConsoleHelper.InputNumber($" {UnitsList.Inches} > ");
                Console.WriteLine();
                Console.WriteLine($" Please enter your Weight in {UnitsList.Stones} and" +
                    $" {UnitsList.Pounds}");
                Stones = ConsoleHelper.InputNumber($" {UnitsList.Stones} > ");
                Pounds = ConsoleHelper.InputNumber($" {UnitsList.Pounds} > ");
            }

            if (UnitChoice.Equals(UnitChoices.Metric))
            {
                Console.WriteLine($" Please enter your Height in {UnitsList.Centimetres}");
                Centimetres = ConsoleHelper.InputNumber($" {UnitsList.Centimetres} > ");
                Console.WriteLine();
                Console.WriteLine($" Please enter your Weight in {UnitsList.Grams}");
                Kilograms = ConsoleHelper.InputNumber($" {UnitsList.Kilograms} > ");
            }
        }

        /// <summary>
        /// Outputs an introduction to the application
        /// </summary>
        private static void OutputIntroduction()
        {
            Console.WriteLine(" This Application is designed to calculate your BMI in " +
                "accordance with the World Health Organisation figures for BMI, as below");
            Console.WriteLine();
            Console.WriteLine($" Underweight = <{BMI_UNDERWEIGHT}");
            Console.WriteLine($" Normal = >{BMI_NORMAL}");
            Console.WriteLine($" Overweight = >{BMI_OVERWEIGHT}");
            Console.WriteLine($" Obese Class I = >{BMI_OBESE_I}");
            Console.WriteLine($" Obese Class II = >{BMI_OBESE_II}");
            Console.WriteLine($" Obese Class III = >{BMI_OBESE_III}");
            Console.WriteLine();
            Console.WriteLine(" All you need to use the Application is your height and weight" +
                " which you can input using Imperial or Metric Units");
            Console.WriteLine();
            Console.WriteLine(" Imperial Units are:");
            Console.WriteLine(" Height: Feet and Inches");
            Console.WriteLine(" Weight: Stones and Pounds");
            Console.WriteLine();
            Console.WriteLine(" Metric Units are:");
            Console.WriteLine(" Height: Centimetres");
            Console.WriteLine(" Weight: Kilograms");
        }

        /// <summary>
        /// Prints a list of choices for the user to select from
        /// </summary>
        private UnitChoices SelectUnit(string prompt)
        {
            string[] choices =
            {
                $" {UnitChoices.Imperial}",
                $" {UnitChoices.Metric}"
            };

            Console.WriteLine(prompt);
            Console.WriteLine();
            int choice = ConsoleHelper.SelectChoice(choices);

            return ExecuteChoice(choice);
        }

        /// <summary>
        /// Executes the choice of unit based on the number inputted 
        /// by the user
        /// </summary>
        private static UnitChoices ExecuteChoice(int choice)
        {
            switch (choice)
            {
                case 1: return UnitChoices.Imperial; 
                case 2: return UnitChoices.Metric;

                default: return UnitChoices.NoUnit;
            }
        }

        /// <summary>
        /// Calculates the user's BMI using the appropriate formula 
        /// based on measurements given
        /// </summary>
        public void CalculateBMI()
        {
            if (UnitChoice.Equals(UnitChoices.Imperial))
            {
                Inches = (Feet * 12) + Inches;
                BMI = ((Stones * 14) + Pounds) * 703 / (Inches * Inches);
            }

            if (UnitChoice.Equals(UnitChoices.Metric))
            {
                Metres = Centimetres / 100;
                BMI = Kilograms / (Metres * Metres);
            }

            CategoriseBMI();
        }

        /// <summary>
        /// Calculates the BMI category using the calculated BMI
        /// </summary>
        public void CategoriseBMI()
        {
            if (BMI < BMI_UNDERWEIGHT)
            {
                Category = UNDERWEIGHT;
            }
            else if (BMI >= BMI_NORMAL && BMI < BMI_OVERWEIGHT)
            {
                Category = NORMAL;
            }
            else if (BMI >= BMI_OVERWEIGHT && BMI < BMI_OBESE_I)
            {
                Category = OVERWEIGHT;
            }
            else if (BMI >= BMI_OBESE_I && BMI < BMI_OBESE_II)
            {
                Category = CLASS_I_OBESE;
            }
            else if (BMI >= BMI_OBESE_II && BMI < BMI_OBESE_III)
            {
                Category = CLASS_II_OBESE;
            }
            else if (BMI >= BMI_OBESE_III)
            {
                Category = CLASS_III_OBESE;
            }
        }

        /// <summary>
        /// Print out the user's BMI and additional information
        /// </summary>
        public void OutputBMI()
        {
            Console.WriteLine();
            Console.WriteLine($" Your BMI is {BMI}. " +
                $"You are in the {Category} Range");
            Console.WriteLine();
            Console.WriteLine(" Please Note: If you are Black, Asian or in " +
                "another Minority Ethnic group, you are at an increased risk " +
                "from BMI");
            Console.WriteLine();
            Console.WriteLine(" Younger children are also at increased risk");
        }
    }
}