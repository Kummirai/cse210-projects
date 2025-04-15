namespace EternalQuest.Models
{
    public class ProgressGoal : Goal
    {
        private int _currentProgress;
        private int _targetProgress;

        public int CurrentProgress => _currentProgress;
        public int TargetProgress => _targetProgress;

        public ProgressGoal(string name, string description, int points, int targetProgress)
            : base(name, description, points)
        {
            _currentProgress = 0;
            _targetProgress = targetProgress;
        }

        public void SetProgress(int progress)
        {
            _currentProgress = progress;
            if (_currentProgress >= _targetProgress)
            {
                _isComplete = true;
            }
        }

        public override void RecordEvent()
        {
            Console.Write(
                $"Enter progress made toward {_name} (current: {_currentProgress}/{_targetProgress}): "
            );
            if (int.TryParse(Console.ReadLine(), out int progress))
            {
                _currentProgress += progress;
                if (_currentProgress >= _targetProgress)
                {
                    _isComplete = true;
                }
            }
        }

        public override string GetProgress() => $"[{_currentProgress}/{_targetProgress}]";

        public override void DisplayGoal()
        {
            Console.WriteLine($"{GetProgress()} {_name}: {_description}");
        }

        public override int GetPoints() => (_points * _currentProgress) / _targetProgress;
    }
}
