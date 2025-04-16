using System;
using ExerciseTracking.Models;

class Program
{
    static void Main(string[] args)
    {
        Running runningActivity = new Running(DateTime.Now, 30, 5);
        Cycling cyclingActivity = new Cycling(DateTime.Now, 45, 20);
        Swimming swimmingActivity = new Swimming(DateTime.Now, 30, 20);

        Console.Clear();
        Console.WriteLine("Exercise Tracking Summary:");
        Console.WriteLine("===================================");
        Console.WriteLine(runningActivity.GetSummary());
        Console.WriteLine(cyclingActivity.GetSummary());
        Console.WriteLine(swimmingActivity.GetSummary());
    }
}