using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep4 World!");

        List<float> numbers = new List<float>();
        float input = -1;
        float total = 0;
        float largestNumber = 0;

        Console.WriteLine("Enter a list of numbers. Type 0 when done.");

        // Loop until user types 0
        while (input != 0)
        {
            Console.Write("Enter a number: ");
            string UserInput = Console.ReadLine();
            input = float.Parse(UserInput);
            if (input != 0)
            {
                numbers.Add(input);
            }
            
        }
        // Adds all the numbers together
        foreach (float number in numbers)
        {
            total += number;
        }

        Console.WriteLine($"The sum is {total}");

        // Finds the average
        Console.WriteLine($"The average is {total / numbers.Count}");

        // Finds the largest number
        foreach (float number in numbers)
        {
            if (number > largestNumber)
            {
                largestNumber = number;
            }
        }
        Console.WriteLine($"The largest number is {largestNumber}");

    }
}