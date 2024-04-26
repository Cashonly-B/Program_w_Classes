using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep2 World!");

        Console.WriteLine("What is your grade percentage? ");
        string GradeInput = Console.ReadLine();
        int grade = int.Parse(GradeInput);

        if (grade > 90)
        {
            Console.Write("You get an A!");
        }
        else if (grade > 80)
        {
            Console.Write("You get a B.");
        }
        else if (grade > 70)
        {
            Console.Write("You get a C.");
        }
        else if (grade > 60)
        {
            Console.Write("You get a D.");
        }
        else
        {
            Console.Write("Sorry you failed the class. You get an F.");
        }
    }
}