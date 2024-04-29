using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep5 World!");

        // Display Welcome
        static void DisplayWelcome()
        {
	        Console.WriteLine("Welcome to the program!");
        }

        // Gets user's name
        static string GetsUsersName()
        {
        	Console.Write("Please Enter Your Name: ");
            string usersName = Console.ReadLine();
            return usersName;
        } 

        // Gets favorite number
        static int GetsUsersNumber()
        {
            Console.Write("Please Enter Your Favorite Number: ");
            string usersNumber = Console.ReadLine();
            int favNumber = int.Parse(usersNumber);
            return favNumber;
        }

        // Squares the number
        static int SquareNumber(int favNumber)
        {
            // Squaring for some reason wasn't working for me, so I just did this
            int total = favNumber * favNumber;
            return total;
        }

        // Displays the results at the end
        static void DisplayResults(string usersName, int total)
        {
            Console.WriteLine($"{usersName}, the square of your number is {total}");
        }

        // Main
        static void main()
        {
            DisplayWelcome();
            string usersName = GetsUsersName();
            int usersNumber = GetsUsersNumber();
            int squaredNumber = SquareNumber(usersNumber);
            DisplayResults(usersName, squaredNumber);
        }

        main();

    }
}