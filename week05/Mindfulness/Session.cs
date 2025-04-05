using System.Text;

public class Session
{
    private DateTime _startTime;
    private DateTime _endTime;
    private List<Activity> _activities;

    public Session()
    {
        _activities = new List<Activity>();
    }
    public void StartSession()
    {
        _startTime = DateTime.Now;
    }

    public void EndSession()
    {
        _endTime = DateTime.Now;
    }

    public double GetSessionDuration()
    {
        TimeSpan duration = _endTime - _startTime;
        return Math.Round(duration.TotalMinutes, 2);
    }

    public int GetTotalActivitiesDuration()
    {
        int totalDuration = 0;
        foreach (var activity in _activities)
        {
            totalDuration += activity.GetActivityDuration();
        }
        return totalDuration;
    }

    public void AddActivity(Activity activity)
    {
        _activities.Add(activity);
    }

    public void DisplayActivitiesSummary()
    {
        StringBuilder summary = new StringBuilder();

        int totalListingActivities = 0, totalReflectingActivities = 0, totalBreathingActivities = 0;
        int totalListingResponses = 0, totalReflectingQuestions = 0, totalBreaths = 0;

        foreach (var activity in _activities)
        {
            if (activity is ListingActivity listingActivity)
            {
                totalListingActivities++;
                totalListingResponses += listingActivity.GetResponseCount();
            }
            else if (activity is ReflectingActivity reflectingActivity)
            {
                totalReflectingActivities++;
                totalReflectingQuestions += reflectingActivity.GetReflectingCount();
            }
            else if (activity is BreathingActivity breathingActivity)
            {
                totalBreathingActivities++;
                totalBreaths += breathingActivity.GetBreathCount();
            }
        }

        summary.AppendLine("========================================");
        summary.AppendLine("SESSION SUMMARY");
        summary.AppendLine("========================================");
        summary.AppendLine($"Total session duration: {GetSessionDuration()} minutes");
        summary.AppendLine($"Total activities: {_activities.Count}");
        summary.AppendLine($"Total activities duration: {GetTotalActivitiesDuration()} seconds");
        summary.AppendLine();

        summary.AppendLine("ACTIVITIES SUMMARY BY TYPE:");
        if (totalListingActivities > 0)
            summary.AppendLine($"- Listing Activities: {totalListingActivities} (Total Responses: {totalListingResponses})");
        if (totalReflectingActivities > 0)
            summary.AppendLine($"- Reflecting Activities: {totalReflectingActivities} (Total Questions: {totalReflectingQuestions})");
        if (totalBreathingActivities > 0)
            summary.AppendLine($"- Breathing Activities: {totalBreathingActivities} (Total Breaths: {totalBreaths})");
        summary.AppendLine();

        summary.AppendLine("DETAILED ACTIVITIES SUMMARY:");
        summary.AppendLine("========================================");

        if (totalBreathingActivities > 0)
        {
            summary.AppendLine("Breathing Activities:");
            foreach (var activity in _activities.OfType<BreathingActivity>())
            {
                summary.AppendLine($"  - {activity.GetActivityName()} ({activity.GetActivityDuration()} seconds)");
                summary.AppendLine($"    Breaths: {activity.GetBreathCount()}");
            }
            summary.AppendLine();
        }

        if (totalReflectingActivities > 0)
        {
            summary.AppendLine("Reflecting Activities:");
            foreach (var activity in _activities.OfType<ReflectingActivity>())
            {
                summary.AppendLine($"  - {activity.GetActivityName()} ({activity.GetActivityDuration()} seconds)");
                summary.AppendLine($"    Questions: {activity.GetReflectingCount()}");
            }
            summary.AppendLine();
        }

        if (totalListingActivities > 0)
        {
            summary.AppendLine("Listing Activities:");
            foreach (var activity in _activities.OfType<ListingActivity>())
            {
                summary.AppendLine($"  - {activity.GetActivityName()} ({activity.GetActivityDuration()} seconds)");
                summary.AppendLine($"    {activity.DisplayListingSummary()}");
            }
            summary.AppendLine();
        }

        summary.AppendLine("========================================");
        Console.WriteLine(summary.ToString());
    }

}