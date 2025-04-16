using System;
using System.Collections.Generic;
using ExerciseTracking.Models;

namespace ExerciseTracking.Services
{
    public class ActivityService
    {
        private List<Activity> _activities;

        public ActivityService()
        {
            _activities = new List<Activity>();
        }

        public void AddActivity(Activity activity)
        {
            _activities.Add(activity);
        }

        public void DisplayActivities()
        {
            foreach (var activity in _activities)
            {
                Console.WriteLine(activity.GetSummary());
            }
        }
    }
}