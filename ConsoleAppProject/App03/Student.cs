using System;
using System.ComponentModel.DataAnnotations;

namespace ConsoleAppProject.App03
{
    /// <summary>
    /// This class is responsible for managing the Database 
    /// of the Web Version of the StudentMarks app
    /// Validates the data for user input.
    /// </summary>
    /// <author>
    /// Nackshayan 1.0.0
    /// </author>
    public class Student
    {
        public int ID { get; set; }

        [StringLength(20), Required]
        public string Name { get; set; }

        [Range(0, 100)]
        public int Mark { get; set; }

        public Grades Grade
        {
            get
            {
                if (Mark >= 0 && Mark < (int)Grades.D)
                    return Grades.F;

                if (Mark >= (int)Grades.D && Mark < (int)Grades.C)
                    return Grades.D;

                if (Mark >= (int)Grades.C && Mark < (int)Grades.B)
                    return Grades.C;

                if (Mark >= (int)Grades.B && Mark < (int)Grades.A)
                    return Grades.B;

                if (Mark >= (int)Grades.A && Mark <= 100)
                    return Grades.A;

                else return Grades.X;
            }
        }
    }
}