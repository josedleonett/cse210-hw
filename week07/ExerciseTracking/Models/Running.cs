using System;

namespace ExerciseTracking.Models
{
    public class Running : Activity
    {
        private double distance; // in kilometers

        public Running(DateTime date, double duration, double distance) : base(date, duration)
        {
            this.distance = distance;
        }

        public override double CalculateDistance()
        {
            return distance;
        }

        public override double CalculateSpeed()
        {
            return distance / (_duration / 60);
        }

        public override double CalculatePace()
        {
            return _duration / distance;
        }

        public override string GetSummary()
        {
            return $"Running:\n" +
                   $"- Date: {_date.ToShortDateString()}\n" +
                   $"- Duration: {_duration} minutes\n" +
                   $"- Distance: {distance:F2} km\n" +
                   $"- Speed: {CalculateSpeed():F2} km/h\n" +
                   $"- Pace: {CalculatePace():F2} min/km";
        }
    }
}