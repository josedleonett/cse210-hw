public class RandomPrompt
{
    public static List<string> _randomPrompt = new List<string> {
        "What did you do today?",
        "What are you grateful for today?",
        "What are you looking forward to tomorrow?",
        "What are you feeling today?",
        "What are you thinking today?",};

    public static string GetRandomPrompt()
    {
        return _randomPrompt[new Random().Next(0, _randomPrompt.Count)];
    }
}