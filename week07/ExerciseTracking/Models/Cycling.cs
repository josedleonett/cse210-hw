using System;

namespace ExerciseTracking.Models
{
    public class Cycling : Activity
    {
        private double _speed; // Speed in miles per hour

        public Cycling(DateTime date, double duration, double speed) : base(date, duration)
        {
            _speed = speed;
        }

        public override double CalculateDistance()
        {
            return _speed * (_duration / 60);
        }

        public override double CalculateSpeed()
        {
            return _speed;
        }

        public override double CalculatePace()
        {
            return 60 / _speed;
        }

        public override string GetSummary()
        {
            return $"Cycling:\n" +
                   $"- Date: {_date.ToShortDateString()}\n" +
                   $"- Duration: {_duration} minutes\n" +
                   $"- Distance: {CalculateDistance():F2} miles\n" +
                   $"- Speed: {CalculateSpeed():F2} mph\n" +
                   $"- Pace: {CalculatePace():F2} min/mile";
        }
    }
}