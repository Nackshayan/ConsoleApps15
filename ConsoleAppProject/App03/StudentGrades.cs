using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App03
{
    /// <summary>
    /// This App will prompt the user to input a grade
    /// for each student contained within a students array
    /// list and it will output the results and grade achieved
    /// for each student, as well as relevant statistics and
    /// grade profile
    /// </summary>
    /// <author>
    /// Nackshayan 1.0.1
    /// </author>
    public class StudentGrades
    {
        public const int lowestF = 0;
        public const int lowestD = 40;
        public const int lowestC = 50;
        public const int lowestB = 60;
        public const int lowestA = 70;
        public const int maxMark = 100;

        public const int MIN = 0;
        public const int MAX = 100;
        public const int Percentage = 100;

        public string[] Students { get; set; }
        public int[] Marks { get; set; }
        public int[] GradeProfile { get; set; }
        public double Mean { get; set; }
        public int Minimum { get; set; }
        public int Maximum { get; set; }
        public int[] Mark { get; set; }

        /// <summary>
        /// Constructor called upon creation of an object
        /// Sets up array of students 
        /// </summary>
        public void Run()
        {
            Students = new string[]
            {
                "Elon", "Bill", "Bruce", "Tony", "Natasha",
                "Kevin", "Ben", "Chris", "Gamora", "Clint", "Pepperpot" 
            };
             
            GradeProfile = new int[(int)Grades.A];
            Marks = new int[]
            {
                10, 20, 30, 40, 50,
                60, 70, 80, 90, 100
            };

            OutputMenuChoices();
        }

        /// <summary>
        /// Outputs the different choices of the application's 
        /// functions for the user to choose from
        /// </summary>
        public void OutputMenuChoices()
        {
            string[] choices =
            {
                " Input Marks",
                " Output Grades",
                " Output Statistics",
                " Output Grade Profile",
                " Quit"
            };

            int choice;
            choice = ExecuteChoice(choices);
        }

        /// <summary>
        /// Prompts the user for their choice of application
        /// Executes the function based on the user's choice
        /// </summary>
        private int ExecuteChoice(string[] choices)
        {
            int choice;
            do
            {
                ConsoleHelper.OutputHeading("App03 - Student Marks");

                choice = ConsoleHelper.SelectChoice(choices);
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        InputMarks();
                        break;
                    case 2:
                        OutputGrades();
                        break;
                    case 3:
                        CalculateStatistics();
                        break;
                    case 4:
                        CalculateGradeProfile();
                        break;

                    default:
                        break;
                }

            } while (choice != 5);
            return choice;
        }

        /// <summary>
        /// Prompts the user to input marks for each student in
        /// the students array
        /// </summary>
        private void InputMarks()
        {
            Console.WriteLine(" Please enter a Mark for each Student");
            Console.WriteLine(" ------------------------------------");

            int i = 0;
            foreach (var student in Students)
            {
                int mark = (int)ConsoleHelper.InputNumber(
                    $" Enter {student}'s Mark > ", MIN, MAX);

                Marks[i] = mark;
                i++;
            };

            Console.WriteLine();
        }

        /// <summary>
        /// Converts the mark for each student, as inputted by the user,
        /// into a grade
        /// </summary>
        public Grades ConvertToGrade(int mark)
        {
            if (mark >= lowestF && mark <= lowestD - 1)
                return Grades.F;
            if (mark >= lowestD && mark <= lowestC - 1)
                return Grades.D;
            if (mark >= lowestC && mark <= lowestB - 1)
                return Grades.C;
            if (mark >= lowestB && mark <= lowestA - 1)
                return Grades.B;
            if (mark >= lowestA && mark <= maxMark)
                return Grades.A;

            else return Grades.X;
        }

        /// <summary>
        /// Outputs a list of the mark awarded to each student as well
        /// as the grade that they have achieved
        /// </summary>
        private void OutputGrades()
        {
            Console.WriteLine(" Results for each Student");
            Console.WriteLine(" ------------------------");

            for (int i = 0; i < 10; i++)
            {
                int mark = Marks[i];
                Grades grade = ConvertToGrade(mark);
                Console.WriteLine($" {Students[i]}'s Mark = {mark}, Grade = {grade}");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Calculates the minimum mark, maximim mark and mean mark
        /// based on each student's mark
        /// </summary>
        public void CalculateStatistics()
        {
            Minimum = Marks[0];
            Maximum = Marks[0];

            double total = 0;

            foreach (int mark in Marks)
            {
                if (mark > Maximum) Maximum = mark;
                if (mark < Minimum) Minimum = mark;

                total += mark;
            }

            Mean = total / Students.Length;

            OutputStatistics();

            Console.WriteLine();
        }

        /// <summary>
        /// Outputs the minimum, maximum and mean marks that
        /// have been calculated based on each mark
        /// </summary>
        private void OutputStatistics()
        {
            Console.WriteLine(" Grade Statistics");
            Console.WriteLine(" ----------------");
            Console.WriteLine($" Minimum Mark is {Minimum}");
            Console.WriteLine($" Maximum Mark is {Maximum}");
            Console.WriteLine($" Mean Mark is {Mean}");
        }

        /// <summary>
        /// Calculates the grade profile based on the mark
        /// awarded to each student
        /// </summary>
        public void CalculateGradeProfile()
        {
            for (int i = 0; i < GradeProfile.Length; i++)
            {
                GradeProfile[i] = 0;
            }

            foreach (int mark in Marks)
            {
                Grades grade = ConvertToGrade(mark);
                GradeProfile[(int)grade-1]++;
            }

            OutputGradeProfile();
        }


        /// <summary>
        /// Outputs the grade profile calculates using the marks
        /// each student has achieved
        /// </summary>
        private void OutputGradeProfile()
        {
            Console.WriteLine(" Grade Profile");
            Console.WriteLine(" -------------");

            Grades grade = Grades.F;
            foreach (int count in GradeProfile)
            {
                int percentage = count * Percentage / Marks.Length;
                Console.WriteLine($" Grade {grade}: Count {count} ({percentage}%)");
                grade++;
            }

            Console.WriteLine();
        }
    }
}