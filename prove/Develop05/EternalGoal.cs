class EternalGoal : Goal{
    private static List<EternalGoal> _eternalGoals = [];
    private string _name;
    private bool _completed = false;
    private int _runningTotal = 0;
    private int _points;
    private static string _self = "Eternal";

    public EternalGoal(string name, bool completed, DateTime date, int points)
     : base(name,completed,date,_self)
     {
        _name = name;
        _completed = completed;
        _points = points;
        _eternalGoals.Add(this);
    }
    
    public void SetRunning(int runningTotal)
    {
        _runningTotal = runningTotal;
    }

    public void CompleteOnce(){
        _runningTotal += _points;
        UpdatePoints(_name,_runningTotal);
    }

    public static EternalGoal CreateEternalGoal(){
        Console.Write("Enter the name of the goal: ");
        string name = Console.ReadLine();

        Console.Write("Put the reward that should be rewarded every time this goal is completed (number): ");
        int points = Convert.ToInt32(Console.ReadLine());

        EternalGoal eternal = new(name, false, DateTime.Now, points); 
        return eternal;
    }

    public static EternalGoal FindEternalGoal(string name = "", bool mute = false)
    {
        foreach(EternalGoal eternal in _eternalGoals)
        {
            if(eternal.GetName() == name)
            {
                return eternal;
            }
        }
        if(mute == false)
        {
            Console.WriteLine($"No goal found under the name {name}");
        }
        return null;
    }
    public static List<EternalGoal> ExportGoals()
    {
        return _eternalGoals;
    }

    protected void GetTotalPoints()
    {
        int grandTotal = 0;
        foreach(EternalGoal eternal in _eternalGoals)
        {
            grandTotal += eternal._runningTotal;
        }
        UpdateTotal(grandTotal);
    }

    // Returns
    public int GetFactor()
    {
        return _points;
    }
    public int GetRunningTotal()
    {
        return _runningTotal;
    }
    public bool GetComplete()
    {
        return _completed;
    }


    // Complete and Close
    public override void CloseGoal()
    {
        UpdateTotal(_runningTotal);
        CompleteGoal(_name, _runningTotal);
        _completed = true;
        Console.WriteLine($"Closed {_self} goal");
    }

}