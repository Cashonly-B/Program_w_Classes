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
        int delay = 250;

        while(duration > 0)
        {
            // 🌕🌖🌗🌘🌑🌒🌓🌔
            // while(length > 0){
            //     Console.SetCursorPosition(left,top);
            //     switch(index){
            //         case 0: Console.Write("-");break;
            //         case 1: Console.Write("\\");break;
            //         case 2: Console.Write("|");break;
            //         case 3: Console.Write("/");break;
            //     }
            //     if(index>=3){index = 0;}else{index +=1;}
            //     length -=1;
            //     Thread.Sleep(delay);
            // }
            Console.SetCursorPosition(left,top);
            Console.Write("|\b");
            Thread.Sleep(delay);
            Console.Write("/\b");
            Thread.Sleep(delay);
            Console.Write("-\b");
            Thread.Sleep(delay);
            Console.Write("\\\b");
            Thread.Sleep(delay);
            duration -= 1;
        }
    }
}

    