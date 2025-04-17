using System;

namespace ExerciseTracking.Models
{
    public class Swimming : Activity
    {
        private int _laps;

        public Swimming(DateTime date, int duration, int laps) : base(date, duration)
        {
            _laps = laps;
        }

        public override double CalculateDistance()
        {
            return _laps * 50 / 1000.0;
        }

        public override double CalculateSpeed()
        {
            return CalculateDistance() / (_duration / 60.0);
        }

        public override double CalculatePace()
        {
            return _duration / CalculateDistance();
        }

        public override string GetSummary()
        {
            return $"Swimming:\n" +
                   $"- Date: {_date.ToShortDateString()}\n" +
                   $"- Duration: {_duration} minutes\n" +
                   $"- Laps: {_laps}\n" +
                   $"- Distance: {CalculateDistance():F2} km\n" +
                   $"- Speed: {CalculateSpeed():F2} km/h\n" +
                   $"- Pace: {CalculatePace():F2} min/km";
        }
    }
}