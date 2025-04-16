using System;

namespace ExerciseTracking
{
    // Swimming class
    public class Swimming : Activity
    {
        private int _laps;

        public Swimming(DateTime date, int duration, int laps)
            : base(date, duration)
        {
            _laps = laps;
        }

        public override double GetDistance() => _laps * 50 / 1000 * 0.62; // miles

        public override double GetSpeed() => (GetDistance() / Duration) * 60;

        public override double GetPace() => Duration / GetDistance();
    }
}
