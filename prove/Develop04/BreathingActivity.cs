class BreathingActivity : Activity
{
    private int _length;
    private int _waittime = 3; //In seconds
    
    public BreathingActivity(int durParam, string titleParam, string descParam)
    : base(durParam, titleParam, descParam)
    {
        int activitylength = _length;
        activitylength /=(_waittime * 2);
        while(activitylength > 0);
        {
            Console.WriteLine("\nBreath In\n");
            Loading();
            Console.WriteLine("\nHold your breath\n");
            Loading();
            Console.WriteLine("\nBreath Out\n");
            Loading();
            activitylength -= 1;
        }
    }
}
