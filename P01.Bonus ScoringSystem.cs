using System;

namespace P01.Bonus_ScoringSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double studentNumber = int.Parse(Console.ReadLine());
            double lecturesNumber = int.Parse(Console.ReadLine());
            double additionalBonus = int.Parse(Console.ReadLine());
             
            double totalBonus = double.MinValue;
            double maxAttendance = 0;


            for (int i = 0; i < studentNumber; i++)
            {                
                double attendanceNumber = int.Parse(Console.ReadLine());

                double maxBonus = ((1.0 * attendanceNumber / lecturesNumber) * (5 + additionalBonus));
                
                if (maxBonus > totalBonus)
                {
                    totalBonus = maxBonus;
                    maxAttendance = attendanceNumber;
                }
            }

            Console.WriteLine($"Max Bonus: {Math.Ceiling(totalBonus)}.");
            Console.WriteLine($"The student has attended {maxAttendance} lectures.");


        }
    }
}
