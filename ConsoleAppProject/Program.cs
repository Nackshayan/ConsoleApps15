using System;
using ConsoleAppProject.App01;
using ConsoleAppProject.App02;
using ConsoleAppProject.App03;

namespace ConsoleAppProject
{
    /// <summary>
    /// The main method in this class is called first
    /// when the application is started.  It will be used
    /// to start Apps 01 to 05 for CO453 
    /// 
    /// This Project has been modified by:
    /// Nackshayan 17/03/2022
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            ConsoleHelper.OutputHeading("CO453 C# Console Applications 2021");

            string[] choices = { "App01: Distance Converter",
                                 "App02: BMI Calculator",
                                 "App03: Student Marks",
                                 "Exit"};

            int choice = ConsoleHelper.SelectChoice(choices);

            switch (choice)
            {
                case 1:
                    DistanceConverter converter = new DistanceConverter();
                    converter.ConvertDistance();
                    break;
                case 2:
                    BMICalculator bmi_calculator = new BMICalculator();
                    bmi_calculator.OutputBMI();
                    break;
                case 3:
                    StudentGrades studentGrades = new StudentGrades();
                    studentGrades.OutputHeading();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }
    }
}
