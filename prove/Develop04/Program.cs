using System;
using System.Runtime.InteropServices;

class MainProgram
{
    static void Main(string[] args)
    {
        int userChoice;
        int duration;
        DateTime time = DateTime.Now;
        bool stopProgram = false;
        int count = 0;

        while(stopProgram == false)
        {
            if(count == 0)
            {
                Console.WriteLine("Hello, welcome to the Mindfullness activity. We hope you have a relaxing time.");
            }
            Console.WriteLine("Select one of the following meditation activites.\n");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Stop Program");
            Console.Write("Choose an activity (number): ");
            userChoice = Convert.ToInt32(Console.ReadLine());
            count += 1;

            //  111  222  333
            if(userChoice == 1 || userChoice == 2 || userChoice == 3)
            {
                Console.Write("\nHow long would you like to do this activity? (in seconds): ");
                duration = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n");

                if(userChoice == 1)
                {
                    BreathingActivity breathing = new(duration, time.ToString(), $"Breathing on {time}");
                    breathing.Start();
                    breathing.StartBreathing();
                    breathing.End();
                }
                if(userChoice == 2)
                {
                    Reflection reflection = new(duration, time.ToString(), $"Reflection on {time}");
                    reflection.Start();
                    reflection.StartReflection();
                    reflection.End();
                }
                if(userChoice == 3)
                {
                    Listing listing = new(duration, time.ToString(), $"Listing on {time}");
                    listing.Start();
                    listing.StartListing();
                    listing.End();
                }
            }
            
            // 44444
            if(userChoice >= 4)
            {
                Console.WriteLine("\nProgram Stopped");
                break;
            }
        }
        Console.Clear();
        Console.SetCursorPosition(0,0);
        Console.WriteLine($"You have completed {count} meditation activies! Nice work!");
        Console.WriteLine("Thank you for meditating with the program. Hope this has helped you! Bye!");
    }
}