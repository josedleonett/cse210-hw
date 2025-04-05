public class BreathingActivity : Activity
{
    private int _breathCount;

    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
        _breathCount = 0;
    }

    public void Run()
    {
        Console.Clear();
        DisplayStartingMessage();
        AskForActivityDuration();

        Console.Clear();
        Console.WriteLine("Get ready to breathe...");
        ShowSpinner();

        int phaseDuration = 5;
        int totalCycles = GetActivityDuration() / (phaseDuration * 2);
        int remainingTime = GetActivityDuration() % (phaseDuration * 2);

        for (int i = 0; i < totalCycles; i++)
        {
            Console.Write("\nBreathe in... ");
            ShowCountdown(phaseDuration);

            Console.Write("\nNow breathe out... ");
            ShowCountdown(phaseDuration);

            _breathCount++;
            Console.WriteLine("");
        }

        if (remainingTime > 0)
        {
            Console.Write("\nBreathe in... ");
            ShowCountdown(remainingTime / 2);

            Console.Write("\nNow breathe out... ");
            ShowCountdown(remainingTime / 2);

            _breathCount++;
            Console.WriteLine("");
        }

        Console.WriteLine("");
        DisplayEndingMessage();
        Console.Clear();
    }

    public int GetBreathCount()
    {
        return _breathCount;
    }

}