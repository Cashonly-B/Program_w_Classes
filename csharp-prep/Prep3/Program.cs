using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep3 World!");
        
        Random randomGenerator = new Random();
        int MagicNumber = randomGenerator.Next(1,101);
        
        int guess = 0;

        while (guess != MagicNumber)
        {
            Console.Write("What is your guess? ");
            string UserGuess = Console.ReadLine();
            guess = int.Parse(UserGuess);

            if (guess < MagicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > MagicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed the number!");
            }
        }
    }
}