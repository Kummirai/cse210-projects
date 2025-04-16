using System;

namespace ExerciseTracking
{
    // Running class
    public class Running : Activity
    {
        private double _distance; // in miles

        public Running(DateTime date, int duration, double distance)
            : base(date, duration)
        {
            _distance = distance;
        }

        public override double GetDistance() => _distance;

        public override double GetSpeed() => (_distance / Duration) * 60;

        public override double GetPace() => Duration / _distance;
    }
}
