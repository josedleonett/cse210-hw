using System;

namespace ExerciseTracking.Models
{
    public abstract class Activity
    {
        protected DateTime _date;
        protected double _duration; // in minutes

        public Activity(DateTime date, double duration)
        {
            _date = date;
            _duration = duration;
        }

        public abstract double CalculateDistance();
        public abstract double CalculateSpeed();
        public abstract double CalculatePace();

        public virtual string GetSummary()
        {
            return $"{GetType().Name}:\n" +
                   $"- Date: {_date.ToShortDateString()}\n" +
                   $"- Duration: {_duration} minutes";
        }
    }
}