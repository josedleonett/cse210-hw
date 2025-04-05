public class PromptResponse
{
    private string _prompt;
    private string _response;
    private string _activityName;
    private DateTime _dateTime;

    public PromptResponse(string prompt, string response, string activityName, DateTime dateTime)
    {
        _prompt = prompt;
        _response = response;
        _activityName = activityName;
        _dateTime = dateTime;
    }

    public string GetPrompt()
    {
        return _prompt;
    }

    public string GetResponse()
    {
        return _response;
    }

    public string GetActivityName()
    {
        return _activityName;
    }

    public DateTime GetDateTime()
    {
        return _dateTime;
    }
    
}