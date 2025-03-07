using System;

class Program
{
    static void Main(string[] args)
    {
        int magicNumberInt = 0;

        Random randomNumber = new Random();
        int number = randomNumber.Next(1, 101);

        while (magicNumberInt != number)
        {
            Console.Write("What is your guess? ");
            string magicNumber = Console.ReadLine();
            magicNumberInt = int.Parse(magicNumber);
            Console.WriteLine(magicNumberInt);

            if (magicNumberInt > number)
            {
                Console.WriteLine("Higher!");
            }
            else if (magicNumberInt < number)
            {
                Console.WriteLine("Lower!");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
    }
}
