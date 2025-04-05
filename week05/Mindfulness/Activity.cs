public class Activity
{
    private string _name;
    private string _description;
    private int _duration; // in seconds

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void AskForActivityDuration()
    {
        Console.Write("How long, in seconds, would you like for your session? ");
        string input = Console.ReadLine();
        _duration = int.Parse(input);
    }

    public int GetActivityDuration()
    {
        return _duration;
    }

    public string GetActivityName()
    {
        return _name;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name} activity! \n");
        Console.WriteLine($"This activity will help you {_description}. \n");
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("Well done!");
        ShowSpinner(3);
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name} activity.");
        ShowSpinner(3);
    }

    public void ShowSpinner(int seconds = 3)
    {
        int endTime = Environment.TickCount + seconds * 1000;
        char[] spinnerChars = { '|', '/', '-', '\\' };
        int spinnerIndex = 0;

        while (Environment.TickCount < endTime)
        {
            Console.Write(spinnerChars[spinnerIndex]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            spinnerIndex = (spinnerIndex + 1) % spinnerChars.Length;
        }
    }

    public void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i}");
            Thread.Sleep(1000);
            Console.Write("\b \b");

        }
    }

}