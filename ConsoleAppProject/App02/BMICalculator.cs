using System;
using System.Text;
using System.ComponentModel.DataAnnotations;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App02
{
    /// <summary>
    /// The unit types for the BMI calculator.
    /// </summary>
    public enum UnitSystems
    {
        [Display(Name = "Imperial")]
        Imperial,
        [Display(Name = "Metric")]
        Metric
    }

    /// <summary>
    /// This App calculates the user's Body Mass Index (BMI) by taking their weight
    /// and height in either imperial or metric units. 
    /// After the values are entered, the user's BMI will be calculated and displayed, 
    /// indicating their weight status according to the W.H.O. guidelines.
    /// </summary>
    /// <author>
    /// Nackshayan V 1. 2
    /// </author>
    public class BMICalculator
    {
        // Constants for W.H.O. weight status (in BMI kg/m2)
        // Maximum thresholds.
        public const double UNDERWEIGHT_MAX = 18.5;
        public const double NORMAL_MAX = 24.9;
        public const double OVERWEIGHT_MAX = 29.9;
        public const double OBESE_I_MAX = 34.9;
        public const double OBESE_II_MAX = 39.9;
        // Minimum threshold.
        public const double OBESE_III_MIN = 40.0;

        public WeightCategories category = WeightCategories.NoCategory;

        // Properties for height and weight in imperial units.
        // Weight = stones (st) and pounds (lb)
        // Height = feet (ft) and inches (in)
        public double Stones { get; set; }
        public double Pounds { get; set; }
        public double Feet { get; set; }
        public double Inches { get; set; }

        // Properties for height and weight in metric units.
        // Weight = kilograms (kg); height = centimetres (cm)
        public double Kilograms { get; set; }
        public double Centimetres { get; set; }

        // Property for user's BMI.
        public double User_BMI { get; set; }

        /// <summary>
        /// Outputs a heading for the App, then shows the user's BMI, weight status and
        /// health risk information after the calculation process has been completed.
        /// </summary>
        public void OutputBMI()
        {
            ConsoleHelper.OutputHeading("Body Mass Index Calculator");

            SelectUnits();

            Console.WriteLine(DisplayWeightStatus());
            Console.WriteLine(DisplayRiskMessage());

            ExitDecision();
        }

        /// <summary>
        /// Prompts the user to select which unit type they would like to use.
        /// (1 for imperial; 2 for metric)
        /// </summary>
        private void SelectUnits()
        {
            Console.WriteLine("\tWhich unit type would you like to use?");

            string[] choices = { EnumHelper<UnitSystems>.GetName(UnitSystems.Imperial),
                EnumHelper<UnitSystems>.GetName(UnitSystems.Metric) };

            int choice = ConsoleHelper.SelectChoice(choices);

            if (choice == 1)
            {
                GetImperialInput();
                CalculateImperial();
            }
            else if (choice == 2)
            {
                GetMetricInput();
                CalculateMetric();
            }
            else
            {
                Console.WriteLine("\tInvalid choice. Please try again.");
                SelectUnits();
            }
        }

        /// <summary>
        /// Prompts the user to enter their weight and height in imperial units
        /// through the console.
        /// </summary>
        public void GetImperialInput()
        {
            Stones = ConsoleHelper.InputNumber("\n\tPlease enter your weight " +
                "in stones > ", 0, 30);
            Pounds = ConsoleHelper.InputNumber("\tPlease enter your weight " +
                "in pounds > ", 0, 300);
            Feet = ConsoleHelper.InputNumber("\n\tPlease enter your height " +
                "in feet > ", 0, 10);
            Inches = ConsoleHelper.InputNumber("\tPlease enter your height " +
                "in inches > ", 0, 50);
        }

        /// <summary>
        /// Calculates the user's BMI based on the imperial units they've
        /// entered.
        /// </summary>
        public void CalculateImperial()
        {
            double weightInPounds = (Stones * 14) + Pounds;
            double heightInInches = (Feet * 12) + Inches;
            User_BMI = ((weightInPounds / heightInInches) / heightInInches) * 703;
        }

        /// <summary>
        /// Prompts the user to input the weight and height in metric units
        /// through the console.
        /// </summary>
        public void GetMetricInput()
        {
            Kilograms = ConsoleHelper.InputNumber("\n\tPlease enter your weight " +
                "in kilograms > ", 0, 150);
            Centimetres = ConsoleHelper.InputNumber("\n\tPlease enter your height " +
                "in centimetres > ", 0, 300);
        }

        /// <summary>
        /// Calculates the user's BMI based on the metric units they've
        /// entered.
        /// </summary>
        public void CalculateMetric()
        {
            User_BMI = Kilograms / Math.Pow((Centimetres / 100), 2);
        }

        /// <summary>
        /// Determines the weight status of the user based on their BMI and the W.H.O's
        /// weight status guidelines. 
        /// </summary>
        /// <returns>A string with the user's current weight status.</returns>
        public string DisplayWeightStatus()
        {
            StringBuilder message = new StringBuilder("\n\t");

            if (User_BMI < UNDERWEIGHT_MAX)
            {
                category = WeightCategories.Underweight;
            }
            else if ((User_BMI > UNDERWEIGHT_MAX) && (User_BMI <= NORMAL_MAX))
            {
                category = WeightCategories.Normal;
            }
            else if ((User_BMI > NORMAL_MAX) && (User_BMI <= OVERWEIGHT_MAX))
            {
                category = WeightCategories.Overweight;
            }
            else if ((User_BMI > OVERWEIGHT_MAX) && (User_BMI <= OBESE_I_MAX))
            {
                category = WeightCategories.ObeseI;
            }
            else if ((User_BMI > OBESE_I_MAX) && (User_BMI <= OBESE_III_MIN))
            {
                category = WeightCategories.ObeseII;
            }
            else if (User_BMI >= OBESE_III_MIN)
            {
                category = WeightCategories.ObeseIII;
            }

            message.Append($"Your BMI is {User_BMI:0.0}. " +
                $"You are {category}.");
            return message.ToString();
        }

        /// <summary>
        /// Outputs a message regarding Black, Asian and other minority ethnic
        /// groups having a higher health risk. 
        /// </summary>
        public string DisplayRiskMessage()
        {
            StringBuilder message = new StringBuilder("\n\t");

            message.Append("If you are Black, Asian or in another minority " +
                "ethnic group, you have a higher health risk.");
            message.Append("\n\tAdults with a BMI of 23.0 or over " +
                "are at increased risk.");
            message.Append("\n\tAdults with a BMI of 27.5 or over " +
                "are at high risk.");

            return message.ToString();
        }

        /// <summary>
        /// Gives the user the option to either exit the application or return
        /// to the menu to calculate another BMI result.
        /// </summary>
        private void ExitDecision()
        {
            Console.Write("\n\tWould you like to exit? Selecting 'n' will return " +
                "you to the menu (y/n) > ");

            string choice = Console.ReadLine();

            if (choice == "y")
            {
                Console.WriteLine("\tThank you for using this calculator. " +
                    "Goodbye for now!");
                Environment.Exit(0);
            }
            else if (choice == "n")
            {
                SelectUnits();
            }
            else
            {
                Console.WriteLine("\tInvalid input. Please try again.");
                ExitDecision();
            }
        }
    }
}
