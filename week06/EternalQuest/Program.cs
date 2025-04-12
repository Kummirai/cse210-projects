using System;
using EternalQuest.Models;
using EternalQuest.Services;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            GoalManager goalManager = new GoalManager();

            Console.WriteLine("Welcome to Eternal Quest!");
            Console.WriteLine("A goal-setting program with gamification elements");

            bool running = true;
            while (running)
            {
                Console.WriteLine("\nMain Menu:");
                Console.WriteLine("1. View Goals");
                Console.WriteLine("2. Create New Goal");
                Console.WriteLine("3. Record Goal Progress");
                Console.WriteLine("4. View Score");
                Console.WriteLine("5. Save Goals");
                Console.WriteLine("6. Load Goals");
                Console.WriteLine("7. View Achievements");
                Console.WriteLine("8. Quit");

                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        goalManager.DisplayGoals();
                        break;
                    case "2":
                        goalManager.CreateGoal();
                        break;
                    case "3":
                        goalManager.RecordGoalEvent();
                        break;
                    case "4":
                        goalManager.DisplayScore();
                        break;
                    case "5":
                        goalManager.SaveGoals();
                        break;
                    case "6":
                        goalManager.LoadGoals();
                        break;
                    case "7":
                        goalManager.DisplayAchievements();
                        break;
                    case "8":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }

            Console.WriteLine("Goodbye! Keep working on your eternal quest!");
        }
    }
}
