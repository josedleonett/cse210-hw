using System;

class Program
{
    static void Main(string[] args)
    {
        // As exceed requirements, I added a improved visualization of the main menu, goal menu creation and save/load system with exceptions.
        GoalManager goalManager = new GoalManager();

        goalManager.Start();
    }
}