using System;

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            Scripture[] scriptureLibrary = new Scripture[]
            {
                new Scripture(
                    new Reference("John", 3, 16),
                    "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."
                ),
                new Scripture(
                    new Reference("Proverbs", 3, 5, 6),
                    "Trust in the LORD with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."
                ),
                new Scripture(
                    new Reference("Philippians", 4, 13),
                    "I can do all this through him who gives me strength."
                ),
                new Scripture(
                    new Reference("Psalm", 23, 1),
                    "The LORD is my shepherd, I lack nothing."
                ),
                new Scripture(
                    new Reference("Romans", 8, 28),
                    "And we know that in all things God works for the good of those who love him, who have been called according to his purpose."
                ),
            };

            Random random = new Random();
            Scripture scripture = scriptureLibrary[random.Next(scriptureLibrary.Length)];

            while (true)
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit:");

                string input = Console.ReadLine();
                if (input.ToLower() == "quit")
                    break;

                scripture.HideRandomWords(3);

                if (scripture.IsCompletelyHidden())
                {
                    Console.Clear();
                    Console.WriteLine(scripture.GetDisplayText());
                    Console.WriteLine("\nAll words are hidden! Press any key to exit.");
                    Console.ReadKey();
                    break;
                }
            }
        }
    }
}
