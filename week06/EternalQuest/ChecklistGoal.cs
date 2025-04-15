namespace EternalQuest.Models
{
    public class ChecklistGoal : Goal
    {
        private int _targetCount;
        private int _currentCount;
        private int _bonusPoints;

        public int TargetCount => _targetCount;
        public int CurrentCount => _currentCount;
        public int BonusPoints => _bonusPoints;

        public ChecklistGoal(
            string name,
            string description,
            int points,
            int targetCount,
            int bonusPoints
        )
            : base(name, description, points)
        {
            _targetCount = targetCount;
            _currentCount = 0;
            _bonusPoints = bonusPoints;
        }

        public override void RecordEvent()
        {
            _currentCount++;
            if (_currentCount >= _targetCount)
            {
                _isComplete = true;
            }
        }

        public override string GetProgress() =>
            _isComplete ? "[X]" : $"[{_currentCount}/{_targetCount}]";

        public override void DisplayGoal()
        {
            Console.WriteLine($"{GetProgress()} {_name}: {_description}");
        }

        public override int GetPoints()
        {
            int total = _points * _currentCount;
            if (_isComplete)
            {
                total += _bonusPoints;
            }
            return total;
        }
    }
}
