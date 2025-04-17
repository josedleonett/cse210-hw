using System;

namespace ExerciseTracking.Models
{
    public class Running : Activity
    {
        private double _distance; // in kilometers

        public Running(DateTime date, double duration, double distance) : base(date, duration)
        {
            _distance = distance;
        }

        public override double CalculateDistance()
        {
            return _distance;
        }

        public override double CalculateSpeed()
        {
            return _distance / (_duration / 60);
        }

        public override double CalculatePace()
        {
            return _duration / _distance;
        }

        public override string GetSummary()
        {
            return $"Running:\n" +
                   $"- Date: {_date.ToShortDateString()}\n" +
                   $"- Duration: {_duration} minutes\n" +
                   $"- Distance: {_distance:F2} km\n" +
                   $"- Speed: {CalculateSpeed():F2} km/h\n" +
                   $"- Pace: {CalculatePace():F2} min/km";
        }
    }
}