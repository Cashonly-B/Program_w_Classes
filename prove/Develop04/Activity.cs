using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;

class Activity
{
    private int _duration;
    private string _time;
    private string _activitySelected;
    private string _entryName;
    

    public Activity(string time = "",string entryName = "",string activitySelected = "", int duration = 0){
        _time = time;
        _entryName = entryName;
        _activitySelected = activitySelected;
        _duration = duration;
    }

    public void Start()
    {
        Console.WriteLine($"Welcome to the {_activitySelected} activity. This activity will last {_duration} seconds");
        Thread.Sleep(1500);
    }

    public void End(){
        Console.Clear();
        Console.SetCursorPosition(0,0);
        Console.WriteLine($"\nThank you for completing: {_entryName}\n");
        Thread.Sleep(3000);
        Console.Clear();
        Console.SetCursorPosition(0,0);
    }

    public void Loading(int duration = 0)
    {
        int left,top;
        (left,top) = Console.GetCursorPosition();

        while(_duration > 0)
        {
            int delay = 250;
            // 🌕🌖🌗🌘🌑🌒🌓🌔

            Console.SetCursorPosition(left,top);
            Console.Write("|\b");
            Thread.Sleep(delay);
            Console.Write("/\b");
            Thread.Sleep(delay);
            Console.Write("-\b");
            Thread.Sleep(delay);
            Console.Write("\\\b");
            Thread.Sleep(delay);
        }
    }
}

    