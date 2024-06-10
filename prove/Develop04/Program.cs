using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop04 World!");
        
        while (true)
        {
            int delay = 250;
            // 🌕🌖🌗🌘🌑🌒🌓🌔
            Console.Write("|\b");
            Thread.Sleep(delay);
            Console.Write("/\b");
            Thread.Sleep(delay);
            Console.Write("-\b");
            Thread.Sleep(delay);
            Console.Write("\\\b");
            Thread.Sleep(delay);

            Activity activity = new(1000, "Breathing", "Breathing in and out");
        }
    }
}