class BreathingActivity : Activity
{
    private int _length;
    //private int _waittime = 3; //In seconds
    private int breatheInTime = 4;
    private int breatheOutTime = 6;
    
    public BreathingActivity(int length, string time, string entryName) 
    : base(time,entryName,"Breathing",length)
    {
        _length = length;
    }

    public void StartBreathing()
    {
        Console.Clear();
        Console.SetCursorPosition(0,0);
        int activityLength = _length/(breatheInTime + breatheOutTime);

        do {
            Console.Clear();
            Console.SetCursorPosition(0,0);
            Console.WriteLine("\nBreath In\n");
            Loading(breatheInTime);
            Console.WriteLine("\nBreath Out\n");
            Loading(breatheOutTime);
            activityLength -= 1;
        } while(_length > 0);
    }  
}
