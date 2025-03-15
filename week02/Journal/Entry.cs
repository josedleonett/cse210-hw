public class Entry
{
    public string _response;
    public string _prompt;
    public DateTime _date;

    public Entry()
    {
        _date = DateTime.Now;
        _prompt = RandomPrompt.GetRandomPrompt();
    }

    public void DisplayEntry()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_prompt}");
        Console.WriteLine(_response);
        Console.WriteLine();
    }

}