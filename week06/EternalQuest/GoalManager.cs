using System;
using System.Collections.Generic;
using System.IO;
using EternalQuest.Models;

namespace EternalQuest.Services
{
    public class GoalManager
    {
        private List<Goal> _goals;
        private int _score;
        private int _level;
        private AchievementService _achievementService;
        private int _streakDays;
        private DateTime _lastRecordDate;

        public GoalManager()
        {
            _goals = new List<Goal>();
            _score = 0;
            _level = 1;
            _achievementService = new AchievementService();
            _streakDays = 0;
            _lastRecordDate = DateTime.MinValue;
        }

        public void DisplayGoals()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals have been created yet.");
                return;
            }

            Console.WriteLine("\nYour Goals:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                _goals[i].DisplayGoal();
            }
        }

        public void CreateGoal()
        {
            Console.WriteLine("\nSelect Goal Type:");
            Console.WriteLine("1. Simple Goal (one-time)");
            Console.WriteLine("2. Eternal Goal (repeating)");
            Console.WriteLine("3. Checklist Goal (requires multiple completions)");
            Console.WriteLine("4. Negative Goal (bad habit to avoid)");
            Console.WriteLine("5. Progress Goal (track progress toward a large goal)");

            Console.Write("Enter goal type: ");
            string typeChoice = Console.ReadLine();

            Console.Write("Enter goal name: ");
            string name = Console.ReadLine();

            Console.Write("Enter goal description: ");
            string description = Console.ReadLine();

            Console.Write("Enter point value: ");
            int points = int.Parse(Console.ReadLine());

            Goal newGoal = null;

            switch (typeChoice)
            {
                case "1":
                    newGoal = new SimpleGoal(name, description, points);
                    break;
                case "2":
                    newGoal = new EternalGoal(name, description, points);
                    break;
                case "3":
                    Console.Write("Enter target count: ");
                    int targetCount = int.Parse(Console.ReadLine());
                    Console.Write("Enter bonus points: ");
                    int bonusPoints = int.Parse(Console.ReadLine());
                    newGoal = new ChecklistGoal(
                        name,
                        description,
                        points,
                        targetCount,
                        bonusPoints
                    );
                    break;
                case "4":
                    newGoal = new NegativeGoal(name, description, points);
                    break;
                case "5":
                    Console.Write("Enter target progress amount: ");
                    int targetProgress = int.Parse(Console.ReadLine());
                    newGoal = new ProgressGoal(name, description, points, targetProgress);
                    break;
                default:
                    Console.WriteLine("Invalid goal type.");
                    return;
            }

            _goals.Add(newGoal);
            Console.WriteLine($"New goal '{name}' created successfully!");

            // Check for first goal achievement
            if (_goals.Count == 1)
            {
                _achievementService.UnlockAchievement("First Step", ref _score);
            }
        }

        public void RecordGoalEvent()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals available to record.");
                return;
            }

            DisplayGoals();
            Console.Write("Enter the number of the goal to record: ");
            if (
                int.TryParse(Console.ReadLine(), out int goalNumber)
                && goalNumber > 0
                && goalNumber <= _goals.Count
            )
            {
                Goal selectedGoal = _goals[goalNumber - 1];

                // Check streak
                DateTime today = DateTime.Today;
                if (_lastRecordDate != today.AddDays(-1))
                {
                    _streakDays = 0;
                }

                selectedGoal.RecordEvent();
                int pointsEarned = selectedGoal.GetPoints();

                // Apply streak bonus
                if (_streakDays > 0)
                {
                    int streakBonus = (int)(pointsEarned * (_streakDays * 0.1)); // 10% bonus per day
                    pointsEarned += streakBonus;
                    Console.WriteLine(
                        $"Streak bonus: +{streakBonus} points ({_streakDays} day streak)"
                    );
                }

                _score += pointsEarned;
                _lastRecordDate = today;
                _streakDays++;

                // Check for level up
                int newLevel = _score / 1000 + 1;
                if (newLevel > _level)
                {
                    Console.WriteLine($"Level Up! You reached level {newLevel}!");
                    _level = newLevel;
                    _achievementService.CheckLevelAchievements(_level, ref _score);
                }

                // Random reward chance (10%)
                Random rand = new Random();
                if (rand.Next(10) == 0)
                {
                    int bonus = rand.Next(10, 51);
                    _score += bonus;
                    Console.WriteLine($"Random Reward! You earned {bonus} bonus points!");
                }

                Console.WriteLine(
                    $"Recorded progress for '{selectedGoal.Name}'. Earned {pointsEarned} points."
                );
                Console.WriteLine($"Total Score: {_score} (Level {_level})");

                _achievementService.CheckScoreAchievements(_score);
            }
            else
            {
                Console.WriteLine("Invalid goal number.");
            }
        }

        public void DisplayScore()
        {
            Console.WriteLine($"\nCurrent Score: {_score} points");
            Console.WriteLine($"Level: {_level}");
            Console.WriteLine($"Current Streak: {_streakDays} days");

            // Calculate points to next level
            int pointsToNextLevel = 1000 - (_score % 1000);
            if (pointsToNextLevel < 1000)
            {
                Console.WriteLine(
                    $"You need {pointsToNextLevel} more points to reach level {_level + 1}"
                );
            }
        }

        public void SaveGoals()
        {
            using (StreamWriter writer = new StreamWriter("goals.txt"))
            {
                writer.WriteLine(_score);
                writer.WriteLine(_level);
                writer.WriteLine(_streakDays);
                writer.WriteLine(_lastRecordDate.ToString());

                foreach (Goal goal in _goals)
                {
                    string goalType = goal.GetType().Name;
                    writer.Write($"{goalType}|{goal.Name}|{goal.IsComplete}|");

                    if (goal is SimpleGoal)
                    {
                        writer.WriteLine();
                    }
                    else if (goal is EternalGoal eternal)
                    {
                        writer.WriteLine();
                    }
                    else if (goal is ChecklistGoal checklist)
                    {
                        writer.WriteLine(
                            $"{checklist.GetPoints()}|{checklist.TargetCount}|{checklist.BonusPoints}"
                        );
                    }
                    else if (goal is NegativeGoal)
                    {
                        writer.WriteLine();
                    }
                    else if (goal is ProgressGoal progress)
                    {
                        writer.WriteLine($"{progress.CurrentProgress}|{progress.TargetProgress}");
                    }
                }
            }

            Console.WriteLine("Goals saved successfully!");
        }

        public void LoadGoals()
        {
            if (!File.Exists("goals.txt"))
            {
                Console.WriteLine("No saved goals found.");
                return;
            }

            _goals.Clear();

            using (StreamReader reader = new StreamReader("goals.txt"))
            {
                _score = int.Parse(reader.ReadLine());
                _level = int.Parse(reader.ReadLine());
                _streakDays = int.Parse(reader.ReadLine());
                _lastRecordDate = DateTime.Parse(reader.ReadLine());

                while (!reader.EndOfStream)
                {
                    string[] parts = reader.ReadLine().Split('|');
                    string goalType = parts[0];
                    string name = parts[1];
                    bool isComplete = bool.Parse(parts[2]);

                    Goal goal = null;

                    switch (goalType)
                    {
                        case "SimpleGoal":
                            goal = new SimpleGoal(name, "", 0);
                            break;
                        case "EternalGoal":
                            goal = new EternalGoal(name, "", 0);
                            break;
                        case "ChecklistGoal":
                            int points = int.Parse(parts[3]);
                            int targetCount = int.Parse(parts[4]);
                            int bonusPoints = int.Parse(parts[5]);
                            goal = new ChecklistGoal(name, "", points, targetCount, bonusPoints);
                            break;
                        case "NegativeGoal":
                            goal = new NegativeGoal(name, "", 0);
                            break;
                        case "ProgressGoal":
                            int currentProgress = int.Parse(parts[3]);
                            int targetProgress = int.Parse(parts[4]);
                            goal = new ProgressGoal(name, "", 0, targetProgress);
                            ((ProgressGoal)goal)._currentProgress = currentProgress;
                            break;
                    }

                    if (goal != null)
                    {
                        goal._isComplete = isComplete;
                        _goals.Add(goal);
                    }
                }
            }

            Console.WriteLine("Goals loaded successfully!");
            Console.WriteLine($"Loaded {_goals.Count} goals with a total score of {_score}.");
        }

        public void DisplayAchievements()
        {
            _achievementService.DisplayAchievements();
        }
    }
}
