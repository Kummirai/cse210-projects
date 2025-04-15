namespace EternalQuest.Models
{
    public abstract class Goal
    {
        protected string _name;
        protected string _description;
        protected int _points;
        protected bool _isComplete;

        public string Name => _name;
        public string Description => _description;
        public int Points => _points;
        public bool IsComplete => _isComplete;

        public Goal(string name, string description, int points)
        {
            _name = name;
            _description = description;
            _points = points;
            _isComplete = false;
        }

        public abstract void RecordEvent();
        public abstract string GetProgress();
        public abstract void DisplayGoal();

        public virtual int GetPoints() => _points;
    }
}
