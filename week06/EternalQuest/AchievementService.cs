using System;
using System.Collections.Generic;
using System.Linq;

namespace EternalQuest.Services
{
    public class AchievementService
    {
        private Dictionary<string, bool> _achievements;

        public AchievementService()
        {
            _achievements = new Dictionary<string, bool>();
            InitializeAchievements();
        }

        private void InitializeAchievements()
        {
            _achievements.Add("First Step", false);
            _achievements.Add("Goal Getter", false);
            _achievements.Add("Eternal Champion", false);
            _achievements.Add("Checklist Master", false);
            _achievements.Add("Level 5", false);
            _achievements.Add("1000 Points", false);
        }

        public void UnlockAchievement(string achievementName, ref int score)
        {
            if (_achievements.ContainsKey(achievementName) && !_achievements[achievementName])
            {
                _achievements[achievementName] = true;
                Console.WriteLine($"Achievement Unlocked: {achievementName}!");
                score += 50; // Bonus for achievement
            }
        }

        public void CheckScoreAchievements(int score)
        {
            if (score >= 1000 && !_achievements["1000 Points"])
            {
                UnlockAchievement("1000 Points", ref score);
            }
        }

        public void CheckLevelAchievements(int level, ref int score)
        {
            if (level >= 5 && !_achievements["Level 5"])
            {
                UnlockAchievement("Level 5", ref score);
            }
        }

        public void DisplayAchievements()
        {
            Console.WriteLine("\nYour Achievements:");
            foreach (var achievement in _achievements)
            {
                Console.WriteLine($"{(achievement.Value ? "[X]" : "[ ]")} {achievement.Key}");
            }

            Console.WriteLine(
                $"\nTotal Achievements Unlocked: {_achievements.Count(a => a.Value)}/{_achievements.Count}"
            );
        }
    }
}
