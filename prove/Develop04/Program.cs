using System;

class Program
{
    static void Main(string[] args)
    {
        int userChoice;
        int duration;

        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");
        Console.WriteLine("Choose an activity (number): ");
        userChoice = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("How long would you like to do this activity? (in seconds): ");
        duration = Convert.ToInt32(Console.ReadLine());
    

        Activity activity = new(1000, "Breathing", "Breathing in and out");
    
    }
}