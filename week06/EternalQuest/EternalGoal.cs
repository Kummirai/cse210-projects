namespace EternalQuest.Models
{
    public class EternalGoal : Goal
    {
        private int _timesCompleted;

        public EternalGoal(string name, string description, int points)
            : base(name, description, points)
        {
            _timesCompleted = 0;
        }

        public override void RecordEvent()
        {
            _timesCompleted++;
        }

        public override string GetProgress() => "[∞]";

        public override void DisplayGoal()
        {
            Console.WriteLine(
                $"{GetProgress()} {_name}: {_description} (Completed {_timesCompleted} times)"
            );
        }

        public override int GetPoints() => _points * _timesCompleted;
    }
}
