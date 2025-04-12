namespace EternalQuest.Models
{
    public class NegativeGoal : Goal
    {
        public NegativeGoal(string name, string description, int points)
            : base(name, description, points) { }

        public override void RecordEvent()
        {
            // Negative goals deduct points
        }

        public override string GetProgress() => _isComplete ? "[X]" : "[ ]";

        public override void DisplayGoal()
        {
            Console.WriteLine(
                $"{GetProgress()} {_name}: {_description} (-{_points} points if done)"
            );
        }

        public override int GetPoints() => -_points;
    }
}
