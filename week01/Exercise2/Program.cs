using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter number of your grade percentage without '%' symbol.");
        int gradePercentage = int.Parse(Console.ReadLine());
        string letter = "";

        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        int gradePercentageLastDigit = gradePercentage % 10;
        string sign = "";

        if (gradePercentageLastDigit >= 7 && gradePercentage <= 90 && gradePercentage >= 60)
        {
            sign = "+";
        }
        else if (gradePercentageLastDigit <= 3 && gradePercentage >= 60)
        {
            sign = "-";
        }

        Console.WriteLine($"Your grade is: {letter}{sign}");

        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You have passed the course!");
        }
        else
        {
            Console.WriteLine("You have not pass the course. Be effort for the next time.");
        }
    }
}