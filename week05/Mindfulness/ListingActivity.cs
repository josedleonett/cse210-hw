public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;
    private List<PromptResponse> _promptResponses;

    public ListingActivity() : base("Listing", "reflect on the good things in your life")
    {
        _count = 0;
        _prompts = new List<string>
        {
            "What are you grateful for?",
            "What is something that made you smile today?",
            "What is a positive experience you had recently?",
            "What is something you love about yourself?",
            "What is a goal you are working towards?"
        };
        _promptResponses = new List<PromptResponse>();
    }

    public void Run()
    {
        Console.Clear();
        DisplayStartingMessage();
        AskForActivityDuration();

        Console.Clear();
        Console.WriteLine("Get ready to list some things...");
        ShowSpinner();

        Console.WriteLine("\nList as many responses you can to the following prompt:");
        Random random = new Random();
        int randomPromptIndex = random.Next(_prompts.Count);
        string randomPrompt = _prompts[randomPromptIndex];
        Console.WriteLine($"--- {randomPrompt} ---");
        Console.WriteLine("You may begin in: ");
        ShowCountdown(5);

        string activityName = GetActivityName();
        DateTime startTime = DateTime.Now;
        int durationInSeconds = GetActivityDuration();

        while ((DateTime.Now - startTime).TotalSeconds < durationInSeconds)
        {
            Console.Write("> ");
            string userResponse = Console.ReadLine();
            if (string.IsNullOrEmpty(userResponse))
            {
                break;
            }
            _count++;
            _promptResponses.Add(new PromptResponse(randomPrompt, userResponse, activityName, DateTime.Now));
        }

        Console.WriteLine($"You listed {_count} items!\n");
        DisplayEndingMessage();
    }

    public int GetResponseCount()
    {
        return _count;
    }

    public void GetRandomPrompt()
    {
        Random random = new Random();
        int randomIndex = random.Next(_prompts.Count);
        Console.WriteLine(_prompts[randomIndex]);
    }

    public string DisplayListingSummary()
    {
        if (_promptResponses.Count == 0)
        {
            return "No responses were provided during the activity.\n";
        }

        string summary = $"You listed {_count} items in the {GetActivityName()} activity.\n";
        summary += $"Prompt: {_promptResponses[0].GetPrompt()}\n";
        summary += "========================================\n";

        for (int i = 0; i < _promptResponses.Count; i++)
        {
            var response = _promptResponses[i];
            summary += $"Response {i + 1}:\n";
            summary += $"  - {response.GetResponse()}\n";
            summary += $"  - Date: {response.GetDateTime():MMMM dd, yyyy hh:mm tt}\n";
            summary += "----------------------------------------\n";
        }

        summary += "========================================\n";
        return summary;
    }
}