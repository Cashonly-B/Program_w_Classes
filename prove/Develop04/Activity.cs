class Activity
{
    protected int _duration;
    protected string _title;
    protected string _description;

    public Activity(int durParam, string titleParam, string descParam)
    {
        _duration = durParam;
        _title = titleParam;
        _description = descParam;
    }

    public void Start()
    {
        Console.WriteLine($"Welcome to the {_title} activity. This activity will last {_duration} seconds");
        Thread.Sleep(1500);
    }

    public void Loading()
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

    