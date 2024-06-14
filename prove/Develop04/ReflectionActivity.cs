using System.ComponentModel.DataAnnotations;

class Reflection : Activity
{
    private int _length;
    private int _timereflect = 5; // In seconds
    private static string _self = "reflection";


    public Reflection(int length, string time, string name)
    : base(time, name, "Reflection", length)
    {
        _length = length;
    }

    public void StartReflection()
    {
        int activityLength = _length;
        string prompt;
        string question;
 
        Console.Clear();
        Console.SetCursorPosition(0,0);
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");

        while(activityLength > 0)
        {
            Console.Clear();
            Console.SetCursorPosition(0,0);
            Prompt reflectList = new();
            reflectList.SetLists();

            prompt = reflectList.GetPrompt(_self);
            Console.WriteLine($"\n{prompt}");
            Thread.Sleep(500);
            activityLength -= 1;

            question = reflectList.GetQuestion(_self);
            Console.WriteLine($"{question}");
            Loading(_timereflect);
            activityLength -= _timereflect;
        }
    }

}