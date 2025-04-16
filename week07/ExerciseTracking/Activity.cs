using System;

namespace ExerciseTracking
{
    // Base Activity class
    public abstract class Activity
    {
        private DateTime _date;
        private int _duration; // in minutes

        public Activity(DateTime date, int duration)
        {
            _date = date;
            _duration = duration;
        }

        public DateTime Date => _date;
        public int Duration => _duration;

        public abstract double GetDistance(); // in miles or km
        public abstract double GetSpeed();    // in mph or kph
        public abstract double GetPace();     // in min per mile or km

        public virtual string GetSummary()
        {
            return $"{_date.ToString("dd MMM yyyy")} {GetType().Name} ({_duration} min) - " +
                   $"Distance: {GetDistance():F1} miles, Speed: {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
        }
    }
}
