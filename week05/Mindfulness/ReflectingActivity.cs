public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private int _reflectingsCount;

    public ReflectingActivity() : base("Reflecting", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless.",
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

    public void Run()
    {
        Console.Clear();
        DisplayStartingMessage();
        AskForActivityDuration();

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner();

        Console.WriteLine("\nConsider the following prompt:");
        Random random = new Random();
        int randomPromptIndex = random.Next(_prompts.Count);
        Console.WriteLine($"\n--- {_prompts[randomPromptIndex]} ---");

        Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder each of the following questions as they relate to this experience.");
        Console.WriteLine("You may begin in: ");
        ShowCountdown(5);

        Console.Clear();
        DateTime endTime = DateTime.Now.AddSeconds(GetActivityDuration());
        List<int> usedQuestionsIndexes = new List<int>();
        while (DateTime.Now < endTime)
        {
            int randomQuestionIndex;

            // Ensure the random question index hasn't been used yet
            do
            {
                randomQuestionIndex = random.Next(_questions.Count);
            } while (usedQuestionsIndexes.Contains(randomQuestionIndex));

            usedQuestionsIndexes.Add(randomQuestionIndex);
            Console.WriteLine($"> {_questions[randomQuestionIndex]} ");
            ShowSpinner(5);

            // if all questions have been used then break the loop
            if (usedQuestionsIndexes.Count == _questions.Count - 1)
            {
                Console.WriteLine("\nYou have answered all the questions availables.");
            }
        }
        
        Console.WriteLine("\n");
        _reflectingsCount = usedQuestionsIndexes.Count;
        DisplayEndingMessage();
    }

    public void GetRandomPrompt()
    {
        Random random = new Random();
        int randomIndex = random.Next(_prompts.Count);
        Console.WriteLine(_prompts[randomIndex]);
    }

    public void GetRandomQuestion()
    {
        Random random = new Random();
        int randomIndex = random.Next(_questions.Count);
        Console.WriteLine(_questions[randomIndex]);
    }

    public int GetReflectingCount()
    {
        return _reflectingsCount;
    }
}