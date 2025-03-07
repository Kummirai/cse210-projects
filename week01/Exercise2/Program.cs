using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is you grade percentage? ");
        string gradePercentage = Console.ReadLine();
        int gradePercentageInt = int.Parse(gradePercentage);
        string letter;

        if (gradePercentageInt >= 90)
        {
            letter = "A";
            if (gradePercentageInt > 70)
            {
                Console.WriteLine("Congratulations you passed!");
            }
        }
        else if (gradePercentageInt >= 80)
        {
            letter = "B";
            if (gradePercentageInt > 70)
            {
                Console.WriteLine("Congratulations you passed!");
            }
        }
        else if (gradePercentageInt >= 70)
        {
            letter = "C";
            if (gradePercentageInt > 70)
            {
                Console.WriteLine("Congratulations you passed!");
            }
        }
        else if (gradePercentageInt >= 60)
        {
            letter = "D";
            if (gradePercentageInt < 70)
            {
                Console.WriteLine("I'm sorry you did not pass this time, but try gain!");
            }
        }
        else
        {
            letter = "F";
            if (gradePercentageInt < 70)
            {
                Console.WriteLine("I'm sorry you did not pass this time, but try gain!");
            }
        }
        Console.WriteLine($"Your Grade is {letter}");
    }
}
