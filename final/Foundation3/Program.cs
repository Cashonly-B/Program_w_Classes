using System;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

public class Program
{
    public static void Main()
    {
        var address1 = new Address("1642 West Bengal Street", "Shelby", "ID", "83112");
        var address2 = new Address("150 South Temple Street", "Youragway", "WS", "54117");
        var address3 = new Address("6583 Moe Dans Ha Circle", "C'esta", "UT", "10101");

        var lecture = new Lecture("Math", "10:30 AM", "Learn addition, subtraction and multiplication!", address1, new DateTime(2024, 9, 1), "Isaac Saxton", 50);
        var reception = new Reception("Wedding", "5:00 PM", "John and Ash are getting married!", address2, new DateTime(2024, 8, 30), "johnandash237@ymail.com");
        var outdoor = new Outdoor("Neighborhood Lunch at Ron's House!", "12:30 PM", "Come eat some yummy food at the Featherson's house! Sandwitches, chips and soda provided.", address3, new DateTime(2024, 7, 14), "Mostly Sunny");

        Event[] eventList = { lecture, reception, outdoor };

        foreach (var eventItem in eventList)
        {
            Console.WriteLine($"{eventItem.RegDetails()} \n");
            Console.WriteLine($"{eventItem.FullDetails()} \n");
            Console.WriteLine($"{eventItem.GetDescription()} \n");
            Console.WriteLine("\n" + new string("=====================") + "\n"); //ChatGPT helped me write this line
        }
    }
}